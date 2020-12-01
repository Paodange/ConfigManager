using System.ComponentModel.DataAnnotations;
using Mgi.Apl.Model.Entity;

namespace Mgi.Apl.Model.BO
{
    public class LookupBO : AbstractBO<Lookup, int?>
    {
        [Required]
        [MaxLength(50, ErrorMessage = "The field [{0}] must be a string with a maximum length of '{1}'")]
        public string LookUpCode { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The field [{0}] must be a string with a maximum length of '{1}'")]
        public string Code { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The field [{0}] must be a string with a maximum length of '{1}'")]
        public string Name { get; set; }
        public int? Sort { get; set; }
    }
}
