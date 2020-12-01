using System.ComponentModel.DataAnnotations.Schema;
using MicroOrm.Dapper.Repositories.Attributes;

namespace Mgi.Apl.Model.Entity
{
    /// <summary>
    /// 物料类型  用于生成PN
    /// </summary>
    [Table("material_type")]
    public class MaterialType : EditableModel<int?>
    {
        [Column("code")]
        [IgnoreUpdate]
        public string Code { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("en_name")]
        public string EnName { get; set; }
        [Column("desc")]
        public string Desc { get; set; }
        [Column("category_id")]
        public int? CategoryId { get; set; }
        [Column("category_name")]
        public string CategoryName { get; set; }
    }
}
