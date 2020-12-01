using System;
using Mgi.Apl.Model.Entity;

namespace Mgi.Apl.Model.DTO
{
    public class UserDTO : AbstractDTO<User, int?>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string MobileNumber { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastLoginTime { get; set; }
    }
}
