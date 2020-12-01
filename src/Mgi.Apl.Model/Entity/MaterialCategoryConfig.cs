using System.ComponentModel.DataAnnotations.Schema;
using MicroOrm.Dapper.Repositories.Attributes;

namespace Mgi.Apl.Model.Entity
{
    [Table("material_category_config")]
    public class MaterialCategoryConfig : AbstractModel<int?>
    {
        [Column("material_category_id")]
        public int? MaterialCategoryId { get; set; }
        [Column("config_key")]
        public string ConfigKey { get; set; }
        [Column("config_key_desc")]
        public string ConfigKeyDesc { get; set; }
        [Column("config_value_type")]
        public string ConfigValueType { get; set; }
        [Column("config_default_value")]
        public string ConfigDefaultValue { get; set; }
        [Column("required")]
        public bool? Required { get; set; }
        [Column("remark")]
        public string Remark { get; set; }

        [Column("sort")]
        [IgnoreUpdate]
        public int? Sort { get; set; }
    }
}
//material_category_id int4    32	0	-1					0	0	0	0
//config_key varchar 255	0	-1			pg_catalog	default	0	0	0	0
//config_key_desc varchar 255	0	-1			pg_catalog	default	0	0	0	0
//config_value_type varchar 255	0	-1			pg_catalog	default	0	0	0	0
//config_default_value varchar 500	0	-1			pg_catalog	default	0	0	0	0
//required bool	0	0	-1					0	0	0	0
