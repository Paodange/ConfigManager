using System.Security.Principal;

namespace Mgi.Apl.Model
{
    public interface IUserIdentity : IIdentity
    {
        int UserId { get; }
        string UserName { get; }
        string RealName { get; }
    }
    public class UserIdentity : IUserIdentity, IIdentity
    {
        public int UserId { get; set; }

        public string UserName { get; set; }
        public string RealName { get; set; }

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
