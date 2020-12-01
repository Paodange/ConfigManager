using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Mgi.Apl.Model.BO;
using Mgi.Apl.Model.DTO;
using Mgi.Apl.Model.Entity;
using Mgi.Apl.Repository;

namespace Mgi.Apl.Service.Impl
{
    public class AttachmentService : AbstractService<Attachment, AttachmentBO, AttachmentDTO, int?>, IAttachmentService
    {
        public AttachmentService(IMapper mapper, IAttachmentRepository repository, IAttachmentRepository attachmentRepository)
            : base(mapper, repository, attachmentRepository)
        {
        }
        public AttachmentDTO GetByGuid(string guid)
        {
            return Mapper.Map<AttachmentDTO>(Repository.SingleOrDefault(x => x.FileGuid == guid));
        }
    }
}
