using Mgi.Apl.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.IO;

namespace Mgi.Apl.Web.Controllers
{
    /// <summary>
    /// 通用文件下载控制器
    /// </summary>
    [Route("api/file")]
    [ApiController]
    [Authorize]
    public class AttachmentController : ControllerBase
    {
        IAttachmentService Service { get; }
        public AttachmentController(IAttachmentService service)
        {
            Service = service;
        }
        /// <summary>
        /// 下载用户上传的附件
        /// </summary>
        /// <param name="id">附件guid</param>
        /// <returns></returns>
        [HttpGet("attachment/{id}")]
        [AllowAnonymous]
        public IActionResult DownloadAttachment(string id)
        {
            var attachment = Service.GetByGuid(id);
            if (attachment == null)
            {
                return NotFound();
            }
            if (attachment.DownloadTimes == null)
            {
                attachment.DownloadTimes = 0;
            }
            var filePath =Path.Combine( PlatformServices.Default.Application.ApplicationBasePath, $"upload/{attachment.Type}/{attachment.FileName}");
            // TODO 下载次数加1
            //attachment.DownloadTimes++;
            //Service.Update(attachment);

            return PhysicalFile(filePath, attachment.ContentType, attachment.OrginalFileName, true);
        }

        /// <summary>
        /// 下载服务器生成的文件 如导出
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult DownloadFile(string id)
        {
            var path = PlatformServices.Default.Application.ApplicationBasePath;
            var attachment = Service.GetByGuid(id);
            if (attachment == null)
            {
                return NotFound();
            }
            if (attachment.DownloadTimes == null)
            {
                attachment.DownloadTimes = 0;
            }
            var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, $"files/{attachment.Type}/{attachment.FileName}");
            // TODO 下载次数加1
            //attachment.DownloadTimes++;
            //Service.Update(attachment);
            return PhysicalFile(filePath, attachment.ContentType, attachment.OrginalFileName, false);

        }
    }
}
