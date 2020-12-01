using System.ComponentModel.DataAnnotations;
using Mgi.Apl.Model.Entity;

namespace Mgi.Apl.Model.BO
{
    public class MaterialBrandBO : AbstractBO<MaterialBrand, int?>
    {
        [RegularExpression("^[A-Z0-9]{2,2}$", ErrorMessage = "The code consists of two uppercase letters or numbers")]
        public string Code { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The field [{0}] must be a string with a maximum length of '{1}'")]
        public string Name { get; set; }
        public string EnName { get; set; }
        [MaxLength(1000, ErrorMessage = "The field [{0}] must be a string with a maximum length of '{1}'")]
        public string Desc { get; set; }
    }
}
