using Mgi.Apl.Service;
using Mgi.Framework.Core.ApiContract;
using System;
using System.Security.Principal;

namespace Mgi.Apl.Web.Data
{
    public class UserIdentity : IUserIdentity, IIdentity
    {
        public int UserId { get; set; }

        public string UserName { get; set; }
        public string RealName { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public string RemoteIP { get; set; }

        public string ComputerName { get; set; }

        public string HardwareId { get; set; }

        public string UserAgent { get; set; }

        public DateTime ExpireTime { get; set; }

        /// <summary>
        /// 返回验证方式
        /// </summary>
        public string AuthenticationType
        {
            get { return "Form"; }
        }
        /// <summary>
        /// 是否验证
        /// </summary>
        public bool IsAuthenticated
        {
            get { return true; }
        }
        /// <summary>
        /// 返回用户
        /// </summary>
        public string Name
        {
            get { return UserName; }
        }
    }
}
