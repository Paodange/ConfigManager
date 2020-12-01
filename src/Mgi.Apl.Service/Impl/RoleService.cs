using AutoMapper;
using Mgi.Apl.Model.BO;
using Mgi.Apl.Model.DTO;
using Mgi.Apl.Model.Entity;
using Mgi.Apl.Repository;

namespace Mgi.Apl.Service.Impl
{
    public class RoleService : AbstractService<Role, RoleBO, RoleDTO, int?>, IRoleService
    {
        public RoleService(IMapper mapper, IRoleRepository repository, IAttachmentRepository attachmentRepository) : base(mapper, repository, attachmentRepository)
        {

        }
    }
}
