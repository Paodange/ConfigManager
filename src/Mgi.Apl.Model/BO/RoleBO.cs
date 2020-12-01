using Mgi.Apl.Model.Entity;

namespace Mgi.Apl.Model.BO
{
    public class RoleBO : AbstractBO<Role, int?>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
