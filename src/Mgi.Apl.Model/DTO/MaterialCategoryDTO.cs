using System;
using System.Collections.Generic;
using Mgi.Apl.Model.Entity;

namespace Mgi.Apl.Model.DTO
{
    public class MaterialCategoryDTO : AbstractDTO<MaterialCategory, int?>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string EnName { get; set; }
        public string Desc { get; set; }
        /// <summary>
        /// 是否需要容器
        /// </summary>
        public bool? RequireContainer { get; set; }
        /// <summary>
        /// 是否手动输入PN
        /// </summary>
        public bool? ManualPartNumber { get; set; }

        /// <summary>
        /// 是否需要料架
        /// </summary>
        public bool? RequireRack { get; set; }
        public DateTime? ModifyTime { get; set; }
        public List<MaterialCategoryConfigDTO> Configs { get; set; }
        /// <summary>
        /// 获取或设置此类别下面是否有物料 用于前端判断是否允许修改参数类型
        /// </summary>
        public bool? HasChildren { get; set; }
    }
}
