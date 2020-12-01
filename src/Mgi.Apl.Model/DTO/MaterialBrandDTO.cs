using System;
using Mgi.Apl.Model.Entity;

namespace Mgi.Apl.Model.DTO
{
    public class MaterialBrandDTO : AbstractDTO<MaterialBrand, int?>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string EnName { get; set; }
        public string Desc { get; set; }
        public DateTime? ModifyTime { get; set; }
    }
}
