using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Mgi.Apl.Model.Entity;

namespace Mgi.Apl.Model.BO
{
    public class MaterialBO : AbstractBO<Material, int?>
    {
        public int? Status { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The field [{0}] must be a string with a maximum length of '{1}'")]
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryCode { get; set; }
        [Required]
        public int? TypeId { get; set; }
        public string TypeName { get; set; }
        [Required]
        public int? BrandId { get; set; }
        public string BrandName { get; set; }
        [MaxLength(1000, ErrorMessage = "The field [{0}] must be a string with a maximum length of '{1}'")]
        public string Desc { get; set; }
        public string PartNumber { get; set; }
        [MaxLength(1000, ErrorMessage = "The field [{0}] must be a string with a maximum length of '{1}'")]
        public string Detail { get; set; }
        public int? ContainerMaterialId { get; set; }
        public string ContainerPartNumber { get; set; }
        /// <summary>
        /// 适用料架id
        /// </summary>
        public int? RackId { get; set; }
        /// <summary>
        /// 适用料架的PN
        /// </summary>
        public string RackPn { get; set; }
        public List<MaterialConfigBO> Configs { get; set; }
    }
}
