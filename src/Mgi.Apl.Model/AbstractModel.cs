
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mgi.Framework.Core;
using MicroOrm.Dapper.Repositories.Attributes;

namespace Mgi.Apl.Model
{
    /// <summary>
    /// 数据库表实体基类
    /// </summary>
    /// <typeparam name="PK"></typeparam>
    public abstract class AbstractModel<PK>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [Identity]
        [IgnoreUpdate]
        public PK Id { get; set; }
    }
}
