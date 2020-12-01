using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Reflection;

namespace Mgi.Apl.Web.Filters
{
    public class AddTokenHeaderOperationFilter : IOperationFilter
    {
        /// <summary>
        /// Adds an authorization header to the given operation in Swagger. 
        /// </summary>
        /// <param name="operation">The Swashbuckle operation.</param>
        /// <param name="context"></param>

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation == null) return;
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }
            var parameter = new OpenApiParameter
            {
                In = ParameterLocation.Header,
                Description = "The authorization token",
                Name = "token",
                Required = true,
                Schema = new OpenApiSchema()
                {
                     Type = "string",
                     Default = new Microsoft.OpenApi.Any.OpenApiString("AAAABBBBCCCC")
                }
            };
            bool b = context.ApiDescription.TryGetMethodInfo(out var m);
            if (b && m.GetCustomAttribute<AllowAnonymousAttribute>() == null)
            {
                operation.Parameters.Add(parameter);
            }
        }
    }
}

