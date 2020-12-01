using Mgi.Apl.Model.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mgi.Apl.Model.BO
{
    public class MaterialCategoryBO : AbstractBO<MaterialCategory, int?>
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9]{1,50}$", ErrorMessage = "The code consists of letters or numbers")]
        [MaxLength(50, ErrorMessage = "The field [{0}] must be a string with a maximum length of '{1}'")]
        public string Code { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The field [{0}] must be a string with a maximum length of '{1}'")]
        public string Name { get; set; }
        public string EnName { get; set; }
        [MaxLength(1000, ErrorMessage = "The field [{0}] must be a string with a maximum length of '{1}'")]
        public string Desc { get; set; }
        /// <summary>
        /// 是否需要容器
        /// </summary>
        public bool? RequireContainer { get; set; }
        /// <summary>
        /// 是否手动输入PN
        /// </summary>
        public bool? ManualPartNumber { get; set; }

        /// <summary>
        /// 需要料架
        /// </summary>
        public bool? RequireRack { get; set; }
        public List<MaterialCategoryConfigBO> Configs { get; set; }
    }
}
