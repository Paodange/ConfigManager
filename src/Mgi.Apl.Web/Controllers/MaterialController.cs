using System;
using System.Collections.Generic;
using System.IO;
using Mgi.Apl.Model.BO;
using Mgi.Apl.Model.DTO;
using Mgi.Apl.Model.Entity;
using Mgi.Apl.Service;
using Mgi.Framework.Core;
using Mgi.Framework.Core.ApiContract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mgi.Apl.Web.Controllers
{
    [Route("api/material")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class MaterialController : ControllerBase
    {
        public IMaterialService Service { get; }
        public MaterialController(IMaterialService service)
        {
            this.Service = service;
        }

        [Route("{id}")]
        [HttpGet]
        public ApiResponse<MaterialDTO> Detail(int id)
        {
            var item = this.Service.GetById(id);
            return new ApiResponse<MaterialDTO>(ResponseCode.Ok, item);
        }

        [HttpPost]
        public ApiResponse<int?> Create(MaterialBO bo)
        {
            var id = this.Service.Add(bo);
            return new ApiResponse<int?>(ResponseCode.Ok, id);
        }
        [HttpPut]
        public ApiResponse<int> Update(MaterialBO bo)
        {
            var rows = this.Service.Update(bo);
            return new ApiResponse<int>(ResponseCode.Ok, rows);
        }

        [Route("{id}")]
        [HttpDelete]
        public ApiResponse<int> Delete(int id)
        {
            var rows = this.Service.Delete(id);
            return new ApiResponse<int>(ResponseCode.Ok, rows);
        }

        [Route("containers/{pn}")]
        [HttpGet]
        public ApiResponse<List<MaterialDTO>> GetContainerMaterials([FromRoute] string pn)
        {
            var data = this.Service.GetContainerMaterials(pn);
            return new ApiResponse<List<MaterialDTO>>(ResponseCode.Ok, data);
        }
        [Route("racks")]
        [HttpGet]
        public ApiResponse<List<MaterialDTO>> GetAllRacks()
        {
            return new ApiResponse<List<MaterialDTO>>(ResponseCode.Ok, this.Service.GetAllRacks());
        }
        [Route("search")]
        [HttpPost]
        public ApiResponse<PageResult<IDictionary<string, object>>> Search(SearchArgs<Material> searchArgs)
        {
            var result = this.Service.SearchDic(searchArgs);
            return new ApiResponse<PageResult<IDictionary<string, object>>>(ResponseCode.Ok, result);
        }

        [HttpGet]
        [AllowAnonymous]
        public ApiResponse<IEnumerable<IDictionary<string, object>>> GetAll()
        {
            var result = this.Service.SearchDic(new SearchArgs<Material>() { Pagination = false });
            return new ApiResponse<IEnumerable<IDictionary<string, object>>>(ResponseCode.Ok, result.Items);
        }

        [HttpGet]
        [Route("offlinePackage")]
        public ApiResponse<string> ExportOfflinePackage()
        {
            var fileId = this.Service.ExportOfflinePackage();
            return new ApiResponse<string>(ResponseCode.Ok, fileId);
        }

        [HttpGet]
        [Route("backup")]
        public ApiResponse<string> Backup()
        {
            var fileId = this.Service.ExportToSql();
            return new ApiResponse<string>(ResponseCode.Ok, fileId);
        }

        [HttpPost]
        [Route("restore")]
        public ApiResponse Restore(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    var sql = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(reader.ReadToEnd()));
                    this.Service.ImportFromSql(sql);
                }
                return ResponseCode.Ok;
            }
        }

        [Route("export/{locale}")]
        [HttpPost]
        public ApiResponse<string> Export([FromRoute] string locale, [FromBody] SearchArgs<Material> searchArgs)
        {
            var fileId = this.Service.Export(locale, ExportTemplate.MaterialExportTemplate, searchArgs);
            return new ApiResponse<string>(ResponseCode.Ok, fileId);
        }
    }
}
