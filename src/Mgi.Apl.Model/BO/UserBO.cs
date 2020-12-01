using Mgi.Apl.Model.Entity;
using System;

namespace Mgi.Apl.Model.BO
{
    public class UserBO : AbstractBO<User, int?>
    {
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string Pwd { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Description { get; set; }
        public DateTime? LastLoginTime { get; set; }
    }
}
