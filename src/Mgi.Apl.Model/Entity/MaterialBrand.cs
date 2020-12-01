using System.ComponentModel.DataAnnotations.Schema;
using MicroOrm.Dapper.Repositories.Attributes;

namespace Mgi.Apl.Model.Entity
{
    [Table("material_brand")]
    public class MaterialBrand : EditableModel<int?>
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
    }
}
//code varchar 255	0	-1			pg_catalog	default	0	0	0	0
//name varchar 255	0	-1			pg_catalog	default	0	0	0	0
//en_name varchar 255	0	-1			pg_catalog	default	0	0	0	0
//desc varchar 500	0	-1			pg_catalog	default	0	0	0	0
