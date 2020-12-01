using Mgi.Apl.Model.Entity;

namespace Mgi.Apl.Model.DTO
{
    public class RoleDTO : AbstractDTO<Role, int?>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
