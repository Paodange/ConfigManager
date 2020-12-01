using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mgi.Apl.Model
{
    /// <summary>
    /// 通用可编辑  带创建时间，创建人 修改时间 修改人信息的实体基类
    /// </summary>
    /// <typeparam name="PK"></typeparam>
    public abstract class EditableModel<PK> : AbstractModel<PK>
    {
        [Column("create_time")]
        public DateTime? CreateTime { get; set; }
        [Column("create_user_id")]
        public int? CreateUserId { get; set; }
        [Column("create_user_name")]
        public string CreateUserName { get; set; }
        [Column("modify_time")]
        public DateTime? ModifyTime { get; set; }
        [Column("modify_user_id")]
        public int? ModifyUserId { get; set; }
        [Column("modify_user_name")]
        public string ModifyUserName { get; set; }
    }
}
