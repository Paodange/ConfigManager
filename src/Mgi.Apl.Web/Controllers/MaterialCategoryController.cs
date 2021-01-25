using Mgi.Apl.Model.BO;
using Mgi.Apl.Model.DTO;
using Mgi.Apl.Model.Entity;
using Mgi.Apl.Service;
using Mgi.Framework.Core;
using Mgi.Framework.Core.ApiContract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mgi.Apl.Web.Controllers
{
    [Route("api/material_category")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    [Authorize]
    public class MaterialCategoryController : ControllerBase
    {
        public IMaterialCategoryService Service { get; }
        public MaterialCategoryController(IMaterialCategoryService service)
        {
            Service = service;
        }

        [Route("{id}")]
        [HttpGet]
        public ApiResponse<MaterialCategoryDTO> Detail(int id)
        {
            return new ApiResponse<MaterialCategoryDTO>(ResponseCode.Ok, Service.GetById(id));
        }

        [HttpPost]
        public ApiResponse<int?> Create(MaterialCategoryBO model)
        {
            return new ApiResponse<int?>(ResponseCode.Ok, Service.Add(model));
        }
        [HttpPut]
        public ApiResponse<int> Update(MaterialCategoryBO model)
        {
            return new ApiResponse<int>(ResponseCode.Ok, Service.Update(model));
        }

        [Route("{id}")]
        [HttpDelete]
        public ApiResponse<int> Delete(int id)
        {
            return new ApiResponse<int>(ResponseCode.Ok, Service.Delete(id));
        }
        [Route("search")]
        [HttpPost]
        public ApiResponse<PageResult<MaterialCategoryDTO>> Search(SearchArgs<MaterialCategory> searchArgs)
        {
            return new ApiResponse<PageResult<MaterialCategoryDTO>>(ResponseCode.Ok, Service.Search(searchArgs));
        }
        [Route("export/{locale}")]
        [HttpPost]
        public ApiResponse<string> Export([FromRoute] string locale, [FromBody] SearchArgs<MaterialCategory> searchArgs)
        {
            var fileId = this.Service.Export(locale, ExportTemplate.MaterialCategoryExportTemplate, searchArgs);
            return new ApiResponse<string>(ResponseCode.Ok, fileId);
        }
    }
}
