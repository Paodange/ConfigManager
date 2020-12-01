using System.ComponentModel.DataAnnotations;
using Mgi.Apl.Model.Entity;

namespace Mgi.Apl.Model.BO
{
    public class MaterialTypeConfigBO : AbstractBO<MaterialTypeConfig, int?>
    {
        public int? MaterialTypeId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The field [{0}] must be a string with a maximum length of '{1}'")]
        public string ConfigKey { get; set; }
        public string ConfigDefaultValue { get; set; }
        public int? Sort { get; set; }
    }
}
