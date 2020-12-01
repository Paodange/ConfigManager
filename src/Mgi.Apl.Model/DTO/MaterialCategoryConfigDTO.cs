using Mgi.Apl.Model.Entity;

namespace Mgi.Apl.Model.DTO
{
    public class MaterialCategoryConfigDTO : AbstractDTO<MaterialCategoryConfig, int?>
    {
        public int? MaterialCategoryId { get; set; }
        public string ConfigKey { get; set; }
        public string ConfigKeyDesc { get; set; }
        public string ConfigValueType { get; set; }
        public string ConfigDefaultValue { get; set; }
        public bool? Required { get; set; }
        public string Remark { get; set; }
        public int? Sort { get; set; }
    }
}
