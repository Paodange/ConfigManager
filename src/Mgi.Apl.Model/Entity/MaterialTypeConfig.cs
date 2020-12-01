using System.ComponentModel.DataAnnotations.Schema;
using MicroOrm.Dapper.Repositories.Attributes;

namespace Mgi.Apl.Model.Entity
{
    [Table("material_type_config")]
    public class MaterialTypeConfig : AbstractModel<int?>
    {
        [Column("material_type_id")]
        public int? MaterialTypeId { get; set; }
        [Column("config_key")]
        public string ConfigKey { get; set; }
        [Column("config_default_value")]
        public string ConfigDefaultValue { get; set; }

        [Column("sort")]
        [IgnoreUpdate]
        public int? Sort { get; set; }
    }
}
