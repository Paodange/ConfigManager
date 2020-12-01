using System;
using System.Collections.Generic;
using Mgi.Apl.Model.Entity;

namespace Mgi.Apl.Model.DTO
{
    public class MaterialTypeDTO : AbstractDTO<MaterialType, int?>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string EnName { get; set; }
        public string Desc { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime? ModifyTime { get; set; }
        public List<MaterialTypeConfigDTO> Configs { get; set; }
    }
}
