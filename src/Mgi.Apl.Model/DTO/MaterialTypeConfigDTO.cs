using Mgi.Apl.Model.Entity;

namespace Mgi.Apl.Model.DTO
{
    public class MaterialTypeConfigDTO : AbstractDTO<MaterialTypeConfig, int?>
    {
        public int? MaterialTypeId { get; set; }
        public string ConfigKey { get; set; }
        public string ConfigKeyDesc { get; set; }
        public string ConfigValueType { get; set; }
        public string ConfigDefaultValue { get; set; }
        public string Remark { get; set; }
        public int? Sort { get; set; }
    }
}
