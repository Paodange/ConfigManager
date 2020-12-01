using System.ComponentModel.DataAnnotations.Schema;
using MicroOrm.Dapper.Repositories.Attributes;

namespace Mgi.Apl.Model.Entity
{
    /// <summary>
    /// 物料大类  绑定各种参数
    /// </summary>
    [Table("material_category")]
    public class MaterialCategory : EditableModel<int?>
    {

        [Column("code")]
        [IgnoreUpdate]
        public string Code { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("en_name")]
        public string EnName { get; set; }

        /// <summary>
        /// 是否需要容器
        /// </summary>
        [Column("require_container")]
        public bool? RequireContainer { get; set; }
        /// <summary>
        /// 是否手动输入PN
        /// </summary>
        [Column("manual_partnumber")]
        public bool? ManualPartNumber { get; set; }

        [Column("require_rack")]
        public bool? RequireRack { get; set; }
        [Column("desc")]
        public string Desc { get; set; }
    }
}
