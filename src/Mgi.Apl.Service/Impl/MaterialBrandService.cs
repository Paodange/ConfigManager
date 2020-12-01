using AutoMapper;
using Mgi.Apl.Model.BO;
using Mgi.Apl.Model.DTO;
using Mgi.Apl.Model.Entity;
using Mgi.Apl.Repository;
using Mgi.Framework.Core.ApiContract;

namespace Mgi.Apl.Service.Impl
{
    public class MaterialBrandService : AbstractService<MaterialBrand, MaterialBrandBO, MaterialBrandDTO, int?>, IMaterialBrandService
    {
        IMaterialRepository MaterialRepository { get; }
        public MaterialBrandService(IMapper mapper, IMaterialBrandRepository repository,
            IMaterialRepository materialRepository, IAttachmentRepository attachmentRepository) : base(mapper, repository, attachmentRepository)
        {
            MaterialRepository = materialRepository;
        }
        public override int? Add(MaterialBrandBO bo)
        {
            var count = Repository.Count(x => x.Code.Equals(bo.Code));
            if (count > 0)
            {
                throw new BusinessException(ResponseCode.CodeAlreadyExists.Format(bo.Code));
            }
            return base.Add(bo);
        }

        public override int Update(MaterialBrandBO bo)
        {
            var brand = Repository.SingleOrDefault(x => x.Code == bo.Code);
            if (brand != null && brand.Id != bo.Id)
            {
                throw new BusinessException(ResponseCode.CodeAlreadyExists.Format(bo.Code));
            }
            return base.Update(bo);
        }

        public override int Delete(int? id)
        {
            if (MaterialRepository.Count(x => x.BrandId == id) > 0)
            {
                throw new BusinessException(ResponseCode.MaterialBrandHasBeenUsed);
            }
            return base.Delete(id);
        }
    }
}
