using AutoMapper;
using Mgi.Apl.Model.BO;
using Mgi.Apl.Model.DTO;
using Mgi.Apl.Model.Entity;
using Mgi.Framework.Core;

namespace Mgi.Apl.Web
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap(typeof(PageResult<>), typeof(PageResult<>));
            CreateMap<Attachment, AttachmentBO>().ReverseMap();
            CreateMap<Attachment, AttachmentDTO>().ReverseMap();
            CreateMap<AttachmentDTO, AttachmentBO>().ReverseMap();

            CreateMap<Lookup, LookupBO>().ReverseMap();
            CreateMap<Lookup, LookupDTO>().ReverseMap();
            CreateMap<LookupDTO, LookupBO>().ReverseMap();

            CreateMap<Material, MaterialBO>().ReverseMap();
            CreateMap<Material, MaterialDTO>().ReverseMap();
            CreateMap<MaterialDTO, MaterialBO>().ReverseMap();

            CreateMap<MaterialBrand, MaterialBrandBO>().ReverseMap();
            CreateMap<MaterialBrand, MaterialBrandDTO>().ReverseMap();
            CreateMap<MaterialBrandDTO, MaterialBO>().ReverseMap();


            CreateMap<MaterialCategory, MaterialCategoryBO>().ReverseMap();
            CreateMap<MaterialCategory, MaterialCategoryDTO>().ReverseMap();
            CreateMap<MaterialCategoryDTO, MaterialCategoryBO>().ReverseMap();

            CreateMap<MaterialCategoryConfig, MaterialCategoryConfigBO>().ReverseMap();
            CreateMap<MaterialCategoryConfig, MaterialCategoryConfigDTO>().ReverseMap();
            CreateMap<MaterialCategoryConfigDTO, MaterialCategoryConfigBO>().ReverseMap();

            CreateMap<MaterialConfig, MaterialConfigBO>().ReverseMap();
            CreateMap<MaterialConfig, MaterialConfigDTO>().ReverseMap();
            CreateMap<MaterialConfigDTO, MaterialConfigBO>().ReverseMap();

            CreateMap<MaterialType, MaterialTypeBO>().ReverseMap();
            CreateMap<MaterialType, MaterialTypeDTO>().ReverseMap();
            CreateMap<MaterialTypeDTO, MaterialTypeBO>().ReverseMap();

            CreateMap<MaterialTypeConfig, MaterialTypeConfigBO>().ReverseMap();
            CreateMap<MaterialTypeConfig, MaterialTypeConfigDTO>().ReverseMap();
            CreateMap<MaterialTypeConfigDTO, MaterialTypeConfigBO>().ReverseMap();

            CreateMap<Role, RoleBO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<RoleDTO, RoleBO>().ReverseMap();


            CreateMap<User, UserBO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserDTO, UserBO>().ReverseMap();
        }
    }
}
