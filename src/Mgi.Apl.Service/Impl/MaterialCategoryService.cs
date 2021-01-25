using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Mgi.Apl.Model.BO;
using Mgi.Apl.Model.DTO;
using Mgi.Apl.Model.Entity;
using Mgi.Apl.Repository;
using Mgi.Framework.Core;
using Mgi.Framework.Core.ApiContract;
using Microsoft.AspNetCore.Http;

namespace Mgi.Apl.Service.Impl
{
    public class MaterialCategoryService : AbstractService<MaterialCategory, MaterialCategoryBO, MaterialCategoryDTO, int?>, IMaterialCategoryService
    {
        IMaterialRepository MaterialRepository { get; }
        IMaterialCategoryConfigRepository ConfigRepository { get; }
        IMaterialTypeRepository MaterialTypeRepository { get; }
        public MaterialCategoryService(IMapper mapper,
            IMaterialCategoryRepository repository,
            IMaterialCategoryConfigRepository configRepository,
            IMaterialRepository materialRepository,
            IMaterialTypeRepository materialTypeRepository,
            IAttachmentRepository attachmentRepository,
             IHttpContextAccessor accessor)
            : base(mapper, repository, attachmentRepository, accessor)
        {
            ConfigRepository = configRepository;
            MaterialRepository = materialRepository;
            MaterialTypeRepository = materialTypeRepository;
        }

        public override MaterialCategoryDTO GetById(int? id)
        {
            var dto = base.GetById(id);
            if (dto != null)
            {
                dto.Configs = Mapper.Map<List<MaterialCategoryConfigDTO>>(ConfigRepository.Find(x => x.MaterialCategoryId == id).OrderBy(x => x.Sort).ToList());
            }
            dto.HasChildren = MaterialRepository.Count(x => x.CategoryId == id) > 0;
            return dto;
        }

        public override int? Add(MaterialCategoryBO bo)
        {
            var count = Repository.Count(x => x.Code.Equals(bo.Code));
            if (count > 0)
            {
                throw new BusinessException(ResponseCode.CodeAlreadyExists.Format(bo.Code));
            }
            if (bo.Configs != null && bo.Configs.Count > 0)  //Key 不能重复校验
            {
                var cnt = bo.Configs.Count;
                var groupCount = bo.Configs.GroupBy(x => x.ConfigKey.ToLower()).Count();
                if (cnt != groupCount)
                {
                    throw new BusinessException(ResponseCode.DuplicateKeyFoundInConfigs);
                }
                var id = base.Add(bo);
                int sort = 10;
                foreach (var config in bo.Configs)
                {
                    config.MaterialCategoryId = id;
                    config.Id = null;
                    config.Sort = sort;
                    sort += 10;  //步长设置为10  方便后期在中间插入
                }

                ConfigRepository.BulkInsert(Mapper.Map<List<MaterialCategoryConfig>>(bo.Configs));
                return id;
            }
            else
            {
                return base.Add(bo);
            }
        }

        public override int Update(MaterialCategoryBO vo)
        {
            var category = Repository.SingleOrDefault(x => x.Code == vo.Code);
            if (category != null && category.Id != vo.Id)
            {
                throw new BusinessException(ResponseCode.CodeAlreadyExists.Format(vo.Code));
            }
            if (vo.Configs != null && vo.Configs.Count > 0)
            {
                var cnt = vo.Configs.Count;
                var groupCount = vo.Configs.GroupBy(x => x.ConfigKey.ToLower()).Count();
                if (cnt != groupCount)
                {
                    throw new BusinessException(ResponseCode.DuplicateKeyFoundInConfigs);
                }

                //判断是否可以修改需要容器 和自定义PN  该类别下已有物料的 不允许修改
                var materialCategory = Repository.SingleOrDefault(x => x.Id == vo.Id);
                if (materialCategory == null)
                {
                    throw new BusinessException(ResponseCode.MaterialCategoryNotExist.Format(vo.Id));
                }
                if ((materialCategory.RequireContainer != vo.RequireContainer
                    || materialCategory.ManualPartNumber != vo.ManualPartNumber
                    || materialCategory.RequireRack != vo.RequireRack)
                    && MaterialRepository.Count(x => x.CategoryId == vo.Id) > 0)
                {
                    throw new BusinessException(ResponseCode.CannotModifyRequireContainerOrManualPn);
                }
                ConfigRepository.Delete(x => x.MaterialCategoryId == vo.Id);
                int sort = 10;
                foreach (var config in vo.Configs)
                {
                    config.MaterialCategoryId = vo.Id;
                    config.Id = null;
                    config.Sort = sort;
                    sort += 10;  //步长设置为10  方便后期在中间插入
                }
                ConfigRepository.BulkInsert(Mapper.Map<List<MaterialCategoryConfig>>(vo.Configs));
            }
            return base.Update(vo);
        }

        public override int Delete(int? id)
        {
            if (MaterialTypeRepository.Count(x => x.CategoryId == id) > 0)
            {
                throw new BusinessException(ResponseCode.MaterialCategoryHasBeenUsed);
            }
            var configs = ConfigRepository.Delete(x => x.MaterialCategoryId == id);
            return base.Delete(id);
        }

        public override PageResult<MaterialCategoryDTO> Search(SearchArgs<MaterialCategory> searchArgs)
        {
            var result = base.Search(searchArgs);
            foreach (var item in result.Items)
            {
                item.Configs = Mapper.Map<List<MaterialCategoryConfigDTO>>(
                    ConfigRepository.Find(x => x.MaterialCategoryId == item.Id).OrderBy(x => x.Sort));
                item.HasChildren = MaterialRepository.Count(x => x.CategoryId == item.Id) > 0;
            }
            return result;
        }
    }
}
