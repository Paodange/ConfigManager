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
    public class MaterialTypeService : AbstractService<MaterialType, MaterialTypeBO, MaterialTypeDTO, int?>, IMaterialTypeService
    {
        IMaterialCategoryService MaterialCategoryService { get; }
        IMaterialRepository MaterialRepository { get; }
        IMaterialTypeConfigRepository MaterialTypeConfigRepository { get; }
        IMaterialConfigRepository MaterialConfigRepository { get; }
        public MaterialTypeService(IMapper mapper,
            IMaterialTypeRepository repository,
            IMaterialCategoryService materialCategoryService,
            IMaterialRepository materialRepository,
            IMaterialTypeConfigRepository materialConfigTypeRepository,
            IMaterialConfigRepository materialConfigRepository,
            IAttachmentRepository attachmentRepository,
            IHttpContextAccessor accessor) : base(mapper, repository, attachmentRepository, accessor)
        {
            MaterialCategoryService = materialCategoryService;
            MaterialRepository = materialRepository;
            MaterialTypeConfigRepository = materialConfigTypeRepository;
            MaterialConfigRepository = materialConfigRepository;
        }
        public override MaterialTypeDTO GetById(int? id)
        {
            var dto = base.GetById(id);
            if (dto != null)
            {
                var categoryDTO = MaterialCategoryService.GetById(dto.CategoryId);
                var typeConfigs = MaterialTypeConfigRepository.Find(x => x.MaterialTypeId == id).ToDictionary(x => x.ConfigKey);
                dto.Configs = categoryDTO.Configs.OrderBy(x => x.Sort).Select(x => new MaterialTypeConfigDTO()
                {
                    ConfigKey = x.ConfigKey,
                    ConfigKeyDesc = x.ConfigKeyDesc,
                    ConfigValueType = x.ConfigValueType,
                    ConfigDefaultValue = typeConfigs.ContainsKey(x.ConfigKey) ? typeConfigs[x.ConfigKey].ConfigDefaultValue : null,
                    MaterialTypeId = dto.Id,
                    Remark = x.Remark,
                    Sort = x.Sort
                }).ToList();
            }
            return dto;
        }
        public override int? Add(MaterialTypeBO bo)
        {
            var count = Repository.Count(x => x.Code.Equals(bo.Code));
            if (count > 0)
            {
                throw new BusinessException(ResponseCode.CodeAlreadyExists.Format(bo.Code));
            }
            var id = base.Add(bo);
            if (bo.Configs != null && bo.Configs.Count > 0)
            {
                bo.Configs.AsParallel().ForAll(x =>
                {
                    x.MaterialTypeId = id;
                    x.Id = null;
                });
                MaterialTypeConfigRepository.BulkInsert(Mapper.Map<List<MaterialTypeConfig>>(bo.Configs));
            }
            return id;
        }

        public override int Update(MaterialTypeBO vo)
        {
            if (Repository.Count(x => x.Code == vo.Code) > 0)
            {
                throw new BusinessException(ResponseCode.CodeAlreadyExists.Format(vo.Code));
            }
            if (vo.Configs != null && vo.Configs.Count > 0)
            {
                MaterialTypeConfigRepository.Delete(x => x.MaterialTypeId == vo.Id);
                MaterialTypeConfigRepository.BulkInsert(Mapper.Map<List<MaterialTypeConfig>>(vo.Configs));
                if (vo.OverrideMaterialConfigs.HasValue && vo.OverrideMaterialConfigs.Value)  //覆盖物料的参数配置
                {
                    var materialIds = MaterialRepository.Find(x => x.TypeId == vo.Id).Select(x => x.Id);
                    foreach (var config in vo.Configs)
                    {
                        var configs = MaterialConfigRepository.Find(x => materialIds.Contains(x.MaterialId));
                        foreach (var item in configs)
                        {
                            item.ConfigValue = config.ConfigDefaultValue;
                        }
                        MaterialConfigRepository.BulkUpdate(configs);
                    }
                }

            }
            return base.Update(vo);
        }

        public override int Delete(int? id)
        {
            if (MaterialRepository.Count(x => x.TypeId == id) > 0)
            {
                throw new BusinessException(ResponseCode.MaterialTypeHasBeenUsed);
            }
            MaterialTypeConfigRepository.Delete(x => x.MaterialTypeId == id);
            return base.Delete(id);
        }


        public override PageResult<MaterialTypeDTO> Search(SearchArgs<MaterialType> searchArgs)
        {
            var result = base.Search(searchArgs);
            foreach (var item in result.Items)
            {
                var typeConfigs = MaterialTypeConfigRepository.Find(x => x.MaterialTypeId == item.Id).OrderBy(x => x.Sort);
                var categoryDTO = MaterialCategoryService.GetById(item.CategoryId);
                item.Configs = categoryDTO.Configs.Select(x => new MaterialTypeConfigDTO()
                {
                    ConfigKey = x.ConfigKey,
                    ConfigKeyDesc = x.ConfigKeyDesc,
                    ConfigValueType = x.ConfigValueType,
                    ConfigDefaultValue = typeConfigs.FirstOrDefault(y => y.ConfigKey == x.ConfigKey) == null ? null :
                    typeConfigs.FirstOrDefault(y => y.ConfigKey == x.ConfigKey).ConfigDefaultValue,
                    MaterialTypeId = item.Id,
                    Remark = x.Remark,
                    Sort = x.Sort
                }).OrderBy(x => x.Sort).ToList();
            }
            return result;
        }
        //protected override PageResult<MaterialTypeDTO> Search(int pageIndex, int pageSize, List<string> whereConditions, List<string> orderByConditions, Dictionary<int, object> parameters)
        //{
        //    var result = base.Search(pageIndex, pageSize, whereConditions, orderByConditions, parameters);
        //    foreach (var item in result.Items)
        //    {
        //        var typeConfigs = Context.Set<MaterialTypeConfig>().Where(x => x.MaterialTypeId == item.Id).OrderBy(x => x.Sort);
        //        var categoryDTO = MaterialCategoryService.GetById(item.CategoryId);
        //        item.Configs = categoryDTO.Configs.Select(x => new MaterialTypeConfigDTO()
        //        {
        //            ConfigKey = x.ConfigKey,
        //            ConfigKeyDesc = x.ConfigKeyDesc,
        //            ConfigValueType = x.ConfigValueType,
        //            ConfigDefaultValue = typeConfigs.FirstOrDefault(y => y.ConfigKey == x.ConfigKey) == null ? null :
        //            typeConfigs.FirstOrDefault(y => y.ConfigKey == x.ConfigKey).ConfigDefaultValue,
        //            MaterialTypeId = item.Id,
        //            Remark = x.Remark,
        //            Sort = x.Sort
        //        }).OrderBy(x => x.Sort).ToList();
        //    }
        //    return result;
        //}
    }
}
