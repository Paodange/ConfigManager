using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Mgi.Apl.Model.Entity;

namespace Mgi.Apl.Model.BO
{
    public class MaterialTypeBO : AbstractBO<MaterialType, int?>
    {
        [RegularExpression("^[A-Z0-9]{2,2}$", ErrorMessage = "The code consists of two uppercase letters or numbers")]
        public string Code { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The field [{0}] must be a string with a maximum length of '{1}'")]
        public string Name { get; set; }
        public string EnName { get; set; }
        [MaxLength(1000, ErrorMessage = "The field [{0}] must be a string with a maximum length of '{1}'")]
        public string Desc { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }

        public bool? OverrideMaterialConfigs { get; set; }

        public List<MaterialTypeConfigBO> Configs { get; set; }
    }
}
