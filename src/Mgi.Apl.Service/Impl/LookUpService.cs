using AutoMapper;
using Mgi.Apl.Model.BO;
using Mgi.Apl.Model.DTO;
using Mgi.Apl.Model.Entity;
using Mgi.Apl.Repository;
using Microsoft.AspNetCore.Http;

namespace Mgi.Apl.Service.Impl
{
    public class LookUpService : AbstractService<Lookup, LookupBO, LookupDTO, int?>, ILookUpService
    {
        public LookUpService(IMapper mapper, ILookUpRepository repository, IAttachmentRepository attachmentRepository, IHttpContextAccessor accessor) : base(mapper, repository, attachmentRepository, accessor)
        {
        }
    }
}
