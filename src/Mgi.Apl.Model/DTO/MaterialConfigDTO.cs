using Mgi.Apl.Model.Entity;
using System;
using System.Collections.Generic;

namespace Mgi.Apl.Model.DTO
{
    public class MaterialConfigDTO : AbstractDTO<MaterialConfig, int?>
    {
        public int? MaterialId { get; set; }
        public string ConfigKey { get; set; }
        public string ConfigKeyDesc { get; set; }
        public string ConfigValue { get; set; }
        public string ConfigValueType { get; set; }
        public bool? Required { get; set; }
        public string Remark { get; set; }
        public int? Sort { get; set; }

    }
}
