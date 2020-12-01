using System.ComponentModel.DataAnnotations;
using Mgi.Apl.Model.Entity;

namespace Mgi.Apl.Model.BO
{
    public class MaterialCategoryConfigBO : AbstractBO<MaterialCategoryConfig, int?>
    {
        public int? MaterialCategoryId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The field [{0}] must be a string with a maximum length of '{1}'")]
        public string ConfigKey { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The field [{0}] must be a string with a maximum length of '{1}'")]
        public string ConfigKeyDesc { get; set; }
        public string ConfigValueType { get; set; }
        public string ConfigDefaultValue { get; set; }
        public bool? Required { get; set; }
        [MaxLength(1000, ErrorMessage = "The field [{0}] must be a string with a maximum length of '{1}'")]
        public string Remark { get; set; }
        public int? Sort { get; set; }
    }
}
