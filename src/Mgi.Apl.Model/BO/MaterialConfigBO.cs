using System.ComponentModel.DataAnnotations;
using Mgi.Apl.Model.Entity;

namespace Mgi.Apl.Model.BO
{
    public class MaterialConfigBO : AbstractBO<MaterialConfig, int?>
    {
        public int? MaterialId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The field [{0}] must be a string with a maximum length of '{1}'")]
        public string ConfigKey { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The field [{0}] must be a string with a maximum length of '{1}'")]
        public string ConfigKeyDesc { get; set; }
        public string ConfigValue { get; set; }
        public int? Sort { get; set; }
    }
}
