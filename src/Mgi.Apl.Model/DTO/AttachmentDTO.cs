using System;
using Mgi.Apl.Model.Entity;

namespace Mgi.Apl.Model.DTO
{
    public class AttachmentDTO : AbstractDTO<Attachment, int?>
    {
        /// <summary>
        /// 主表id  一对多时需要 
        /// </summary>
        public int? MainId { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 附件类型  用于区分不同的记录类型的附件
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 对应的http Content-Type
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// 文件名后缀
        /// </summary>
        public string FileExtention { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public int? Size { get; set; }
        /// <summary>
        /// MD5
        /// </summary>
        public string MD5 { get; set; }
        /// <summary>
        /// SHA256值
        /// </summary>
        public string SHA { get; set; }
        /// <summary>
        /// 文件版本
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 下载次数
        /// </summary>
        public int? DownloadTimes { get; set; }

        public DateTime? CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string CreateUserName { get; set; }

        public string FileGuid { get; set; }
        public string OrginalFileName { get; set; }
    }
}
