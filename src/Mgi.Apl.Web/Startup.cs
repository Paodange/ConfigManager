using Autofac;
using AutoMapper;
using Mgi.Apl.Service;
using Mgi.Apl.Web.Filters;
using Mgi.Apl.Web.Interceptors;
using Mgi.Framework.Core;
using Mgi.Framework.Core.ApiContract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mgi.Apl.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region JWT
            // configure strongly typed settings objects
            var section = Configuration.GetSection("Jwt");
            services.Configure<JwtSetting>(section);
            var jwtSetting = section.Get<JwtSetting>();
            var key = Encoding.ASCII.GetBytes(jwtSetting.Secret);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Events = new JwtBearerEvents()
                {
                    OnTokenValidated = context =>
                    {
                        Thread.CurrentPrincipal = context.Principal;
                        return Task.CompletedTask;
                    }
                };
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,//是否验证Issuer
                    ValidateAudience = true,//是否验证Audience
                    ValidateLifetime = true,//是否验证失效时间
                    ValidateIssuerSigningKey = true,//是否验证SecurityKey
                    ValidAudience = jwtSetting.Audience,
                    ValidIssuer = jwtSetting.Issuer, //Issuer，这两项和签发jwt的设置一致
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                };
            });
            #endregion
            services.AddHttpContextAccessor();
            services.AddControllers(
                            options =>
                            {
                                options.EnableEndpointRouting = false;
                                options.Filters.Add<ApiExceptionFilter>();
                                options.Filters.Add<ApiInvokeLogFilter>();
                            })
                            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                            .AddControllersAsServices().AddJsonOptions(options =>
                            {
                                //options.JsonSerializerOptions.DictionaryKeyPolicy = null;
                                //options.JsonSerializerOptions.PropertyNamingPolicy = null;
                            });
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (ctx) =>
                {
                    var errors = ctx.ModelState
                                        .Where(e => e.Value.Errors.Count > 0)
                                        .Select(e => e.Value.Errors.First().ErrorMessage)
                                        .ToList();
                    var message = string.Join("|", errors);
                    var result = new ApiResponse(ResponseCode.ModelValidateError.Format(message));
                    return new OkObjectResult(result);
                };
            });
            services.AddAutoMapper(config => config.AddProfile<AutoMapperProfile>(), typeof(Startup).Assembly);
            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                ////swagger中控制请求的时候发是否需要在url中增加token
                //c.OperationFilter<AddTokenHeaderOperationFilter>();
                c.ResolveConflictingActions(x => x.First());
            });
            //services.AddSingleton<IFileProvider>(
            //     new PhysicalFileProvider(Directory.GetCurrentDirectory()));
            #region 数据库连接字符串
            ConnectionManager.MasterConnectionString = Configuration.GetConnectionString("master"); //主库
            ConnectionManager.SlaveConnectionString = Configuration.GetConnectionString("slave");   //从库
            #endregion
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<ServiceInterceptor>();
            builder.RegisterType<RepositoryInterceptor>();
            builder.RegisterAssemblyTypes(Assembly.Load("Mgi.Apl.Service"))
                .AsImplementedInterfaces()
                //.EnableInterfaceInterceptors()
                //.InterceptedBy(typeof(ServiceInterceptor))
                .PropertiesAutowired();
            builder.RegisterAssemblyTypes(Assembly.Load("Mgi.Apl.Repository"))
                .AsImplementedInterfaces()
                //.EnableInterfaceInterceptors()
                //.InterceptedBy(typeof(RepositoryInterceptor))
                .PropertiesAutowired();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //配置Swagger-------------------//
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DemoAPI V1");
            });

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });
            //var options = new DefaultFilesOptions();
            //options.DefaultFileNames.Add("index.html");    //将index.html改为需要默认起始页的文件名.
            //app.UseDefaultFiles(options);
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    ServeUnknownFileTypes = true
            //});
            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
            };
            options.StaticFileOptions.ServeUnknownFileTypes = true;
            options.DefaultFilesOptions.DefaultFileNames = new[] { "index.html" };
            app.UseFileServer(options);
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseEndpoints(x => x.MapControllers());
        }
    }
}
