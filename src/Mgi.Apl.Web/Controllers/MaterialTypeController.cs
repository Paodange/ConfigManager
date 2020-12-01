using Mgi.Apl.Model.BO;
using Mgi.Apl.Model.DTO;
using Mgi.Apl.Model.Entity;
using Mgi.Apl.Service;
using Mgi.Framework.Core;
using Mgi.Framework.Core.ApiContract;
using Microsoft.AspNetCore.Mvc;

namespace Mgi.Apl.Web.Controllers
{
    [Route("api/material_type")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class MaterialTypeController : ControllerBase
    {
        public IMaterialTypeService Service { get; }
        public MaterialTypeController(IMaterialTypeService service)
        {
            this.Service = service;
        }

        [Route("{id}")]
        [HttpGet]
        public ApiResponse<MaterialTypeDTO> Detail(int id)
        {
            var item = Service.GetById(id);
            return new ApiResponse<MaterialTypeDTO>(ResponseCode.Ok, item);
        }

        [HttpPost]
        public ApiResponse<int?> Create(MaterialTypeBO bo)
        {
            var id = Service.Add(bo);
            return new ApiResponse<int?>(ResponseCode.Ok, id);
        }
        [HttpPut]
        public ApiResponse<int> Update(MaterialTypeBO bo)
        {
            int rows = Service.Update(bo);
            return new ApiResponse<int>(ResponseCode.Ok, rows);
        }

        [Route("{id}")]
        [HttpDelete]
        public ApiResponse<int> Delete(int id)
        {
            int rows = this.Service.Delete(id);
            return new ApiResponse<int>(ResponseCode.Ok, rows);
        }
        [Route("search")]
        [HttpPost]
        public ApiResponse<PageResult<MaterialTypeDTO>> Search(SearchArgs<MaterialType> searchArgs)
        {
            var result = Service.Search(searchArgs);
            return new ApiResponse<PageResult<MaterialTypeDTO>>(ResponseCode.Ok, result);
        }

        [Route("export/{locale}")]
        [HttpPost]
        public ApiResponse<string> Export([FromRoute] string locale, [FromBody] SearchArgs<MaterialType> searchArgs)
        {
            var fileId = Service.Export(locale, ExportTemplate.MaterialTypeExportTemplate, searchArgs);
            return new ApiResponse<string>(ResponseCode.Ok, fileId);
        }
    }
}
