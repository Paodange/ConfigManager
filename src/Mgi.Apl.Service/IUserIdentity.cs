using System;
using System.Security.Principal;

namespace Mgi.Apl.Service
{
    public interface IUserIdentity : IIdentity
    {
        int UserId { get; }
        string UserName { get; }
        string RealName { get; }
        string Password { get; }
        string Role { get; }
        string RemoteIP { get; }
        string ComputerName { get; }
        string HardwareId { get; }
        string UserAgent { get; }
        DateTime ExpireTime { get; set; }
    }
}
