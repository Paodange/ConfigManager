using Mgi.Apl.Model.BO;
using Mgi.Apl.Model.DTO;
using Mgi.Apl.Model.Entity;
using Mgi.Apl.Service;
using Mgi.Framework.Core;
using Mgi.Framework.Core.ApiContract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace Mgi.Apl.Web.Controllers
{
    [Route("api/material_brand")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    [Authorize]
    public class MaterialBrandController : ControllerBase
    {
        public IMaterialBrandService Service { get; }
        public MaterialBrandController(IMaterialBrandService service)
        {
            Service = service;
        }

        [Route("{id}")]
        [HttpGet]
        public ApiResponse<MaterialBrandDTO> Detail(int id)
        {
            return new ApiResponse<MaterialBrandDTO>(ResponseCode.Ok, Service.GetById(id));
        }

        [HttpPost]
        public ApiResponse<int?> Create(MaterialBrandBO model)
        {
            return new ApiResponse<int?>(ResponseCode.Ok, Service.Add(model));
        }
        [HttpPut]
        public ApiResponse<int> Update(MaterialBrandBO model)
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
        public ApiResponse<PageResult<MaterialBrandDTO>> Search(SearchArgs<MaterialBrand> searchArgs)
        {
            return new ApiResponse<PageResult<MaterialBrandDTO>>(ResponseCode.Ok, Service.Search(searchArgs));
        }

        [Route("export/{locale}")]
        [HttpPost]
        public ApiResponse<string> Export([FromRoute] string locale, [FromBody] SearchArgs<MaterialBrand> searchArgs)
        {
            var fileId = this.Service.Export(locale, ExportTemplate.MaterilBrandExportTemplate, searchArgs);
            return new ApiResponse<string>(ResponseCode.Ok, fileId);
        }
    }
}
