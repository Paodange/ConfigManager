using Mgi.Apl.Model.Entity;

namespace Mgi.Apl.Model.DTO
{
    public class LookupDTO : AbstractDTO<Lookup, int?>
    {
        public string LookUpCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Sort { get; set; }
    }
}
