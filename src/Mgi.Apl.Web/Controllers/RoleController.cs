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
    [Route("api/role")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        public IRoleService Service { get; }
        public RoleController(IRoleService service)
        {
            Service = service;
        }

        [Route("{id}")]
        [HttpGet]
        public ApiResponse<RoleDTO> Detail(int id)
        {
            return new ApiResponse<RoleDTO>(ResponseCode.Ok, Service.GetById(id));
        }

        [HttpPost]
        public ApiResponse<int?> Create(RoleBO model)
        {
            return new ApiResponse<int?>(ResponseCode.Ok, Service.Add(model));
        }
        [HttpPut]
        public ApiResponse<int> Update(RoleBO model)
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
        public ApiResponse<PageResult<RoleDTO>> Search(SearchArgs<Role> searchArgs)
        {
            return new ApiResponse<PageResult<RoleDTO>>(ResponseCode.Ok, Service.Search(searchArgs));
        }
    }
}
