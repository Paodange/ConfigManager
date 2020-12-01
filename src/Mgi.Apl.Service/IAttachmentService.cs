using Mgi.Apl.Model.BO;
using Mgi.Apl.Model.DTO;
using Mgi.Apl.Model.Entity;

namespace Mgi.Apl.Service
{
    public interface IAttachmentService : IBaseService<Attachment, AttachmentBO, AttachmentDTO, int?>
    {
        AttachmentDTO GetByGuid(string guid);
    }
}
