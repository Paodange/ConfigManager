using System;
using System.Collections.Generic;
using Mgi.Apl.Model.Entity;

namespace Mgi.Apl.Model.DTO
{
    public class MaterialDTO : AbstractDTO<Material, int?>
    {
        public int? Status { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public int? TypeId { get; set; }
        public string TypeName { get; set; }
        public int? BrandId { get; set; }
        public string BrandName { get; set; }
        public string Desc { get; set; }
        public string PartNumber { get; set; }
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
        public DateTime? ModifyTime { get; set; }
        public List<MaterialConfigDTO> Configs { get; set; }

    }
}
