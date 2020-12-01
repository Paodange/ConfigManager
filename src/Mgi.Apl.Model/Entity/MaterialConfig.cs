using System.ComponentModel.DataAnnotations.Schema;
using MicroOrm.Dapper.Repositories.Attributes;

namespace Mgi.Apl.Model.Entity
{
    [Table("material_config")]
    public class MaterialConfig : AbstractModel<int?>
    {
        [Column("material_id")]
        public int? MaterialId { get; set; }
        [Column("config_key")]
        public string ConfigKey { get; set; }
        [Column("config_value")]
        public string ConfigValue { get; set; }
        [Column("sort")]
        [IgnoreUpdate]
        public int? Sort { get; set; }
    }
}
//material_id int4    32	0	-1					0	0	0	0
//config_key varchar 255	0	-1			pg_catalog	default	0	0	0	0
//config_key_desc varchar 255	0	-1			pg_catalog	default	0	0	0	0
//config_value varchar 500	0	-1			pg_catalog	default	0	0	0	0
