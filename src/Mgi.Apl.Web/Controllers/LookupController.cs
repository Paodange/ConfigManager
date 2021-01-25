using Mgi.Apl.Model.BO;
using Mgi.Apl.Model.DTO;
using Mgi.Apl.Model.Entity;
using Mgi.Apl.Service;
using Mgi.Framework.Core;
using Mgi.Framework.Core.ApiContract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Mgi.Apl.Web.Controllers
{
    [Route("api/lookup")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    [Authorize]
    public class LookupController : ControllerBase
    {
        public ILookUpService Service { get; }
        public LookupController(ILookUpService service)
        {
            Service = service;
        }

        [Route("{id}")]
        [HttpGet]
        public ApiResponse<LookupDTO> Detail(int id)
        {
            return new ApiResponse<LookupDTO>(ResponseCode.Ok, Service.GetById(id));
        }

        [HttpPost]
        public ApiResponse<int?> Create(LookupBO model)
        {
            return new ApiResponse<int?>(ResponseCode.Ok, Service.Add(model));
        }
        [HttpPut]
        public ApiResponse<int> Update(LookupBO model)
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
        public ApiResponse<PageResult<LookupDTO>> Search(SearchArgs<Lookup> searchArgs)
        {
            return new ApiResponse<PageResult<LookupDTO>>(ResponseCode.Ok, Service.Search(searchArgs));
        }
        [Route("category/{lookupCode}")]
        [HttpGet]
        public ApiResponse<IEnumerable<LookupDTO>> GetByLookupCode(string lookupCode)
        {
            var searchArgs = new SearchArgs<Lookup>()
            {
                Model = new Lookup() { LookUpCode = lookupCode },
                Pagination = false
            };
            var result = Service.Search(searchArgs);
            return new ApiResponse<IEnumerable<LookupDTO>>(ResponseCode.Ok, result.Items);
        }
    }
}
