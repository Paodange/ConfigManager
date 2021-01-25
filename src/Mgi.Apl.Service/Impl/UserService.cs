using AutoMapper;
using Mgi.Apl.Model.BO;
using Mgi.Apl.Model.DTO;
using Mgi.Apl.Model.Entity;
using Mgi.Apl.Repository;
using Mgi.Framework.Core.ApiContract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mgi.Apl.Service.Impl
{
    public class UserService : AbstractService<User, UserBO, UserDTO, int?>, IUserService
    {
        readonly JwtSetting _jwtSetting;
        public UserService(IMapper mapper, IUserRepository repository, IAttachmentRepository attachmentRepository,
            IOptions<JwtSetting> jwtSetting, IHttpContextAccessor accessor) : base(mapper, repository, attachmentRepository, accessor)
        {
            _jwtSetting = jwtSetting.Value;
        }

        public string Login(LoginBO bo)
        {
            return GenerateToken(new User()
            {
                Email = "ldp@mgi.com",
                UserName = "admin",
                RealName = "admin",
                Id = 1
            });
        }


        private string GenerateToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(_jwtSetting.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Audience = _jwtSetting.Audience,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id",user.Id.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.UserName),
                    new Claim(ClaimTypes.Name, user.RealName),
                    new Claim(ClaimTypes.Email, user.Email),
                }),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                Issuer = _jwtSetting.Issuer,
                IssuedAt = DateTime.Now
            };
            //var token = tokenHandler.CreateToken(securityTokenDescriptor);
            //var tokenString = tokenHandler.WriteToken(token);

            return tokenHandler.WriteToken(tokenHandler.CreateJwtSecurityToken(securityTokenDescriptor));

        }
    }
}
