using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mgi.Apl.Model.Entity
{
    /// <summary>
    /// 通用附件存储表
    /// </summary>
    [Table("attachment")]
    public class Attachment : EditableModel<int?>
    {
        public Attachment()
        {
            FileGuid = Guid.NewGuid().ToString("N");
        }
        /// <summary>
        /// 主表id  一对多时需要 
        /// </summary>
        [Column("main_id")]
        public int? MainId { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        [Column("file_name")]
        public string FileName { get; set; }

        /// <summary>
        /// 原始文件名  用于下载的时候  恢复给用户原始文件名
        /// </summary>
        [Column("orginal_file_name")]
        public string OrginalFileName { get; set; }
        /// <summary>
        /// 附件类型  用于区分不同的记录类型的附件
        /// </summary>
        [Column("type")]
        public string Type { get; set; }
        /// <summary>
        /// 对应的http Content-Type
        /// </summary>
        [Column("content_type")]
        public string ContentType { get; set; }
        /// <summary>
        /// 文件名后缀
        /// </summary>
        [Column("file_extention")]
        public string FileExtention { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        [Column("size")]
        public long? Size { get; set; }
        /// <summary>
        /// MD5
        /// </summary>
        [Column("md5")]
        public string MD5 { get; set; }
        /// <summary>
        /// SHA256值
        /// </summary>
        [Column("sha")]
        public string SHA { get; set; }
        /// <summary>
        /// 文件版本
        /// </summary>
        [Column("version")]
        public string Version { get; set; }
        /// <summary>
        /// 下载次数
        /// </summary>
        [Column("download_times")]
        public int? DownloadTimes { get; set; }

        /// <summary>
        /// 文件guid  下载时使用  避免int型id 容易猜出下载路径
        /// </summary>
        [Column("file_guid")]
        public string FileGuid { get; set; }
    }
}
