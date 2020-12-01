using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mgi.Apl.Model.Entity
{
    [Table("sys_user")]
    public class User : EditableModel<int?>
    {
        [Column("user_name")]
        public string UserName { get; set; }
        [Column("real_name")]
        public string RealName { get; set; }
        [Column("password")]
        public string Pwd { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("mobile")]
        public string Mobile { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("last_login_time")]
        public DateTime? LastLoginTime { get; set; }
    }
}
//user_name varchar 255	0	-1			pg_catalog	default	0	0	0	0
//real_name varchar 255	0	-1			pg_catalog	default	0	0	0	0
//password varchar 255	0	-1			pg_catalog	default	0	0	0	0
//email varchar 255	0	-1			pg_catalog	default	0	0	0	0
//mobile varchar 255	0	-1			pg_catalog	default	0	0	0	0
//description varchar 255	0	-1			pg_catalog	default	0	0	0	0
//last_login_time timestamp   6	0	-1					0	0	0	0
