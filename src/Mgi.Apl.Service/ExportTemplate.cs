using System;
using System.Collections.Generic;
using System.Text;
using Mgi.Apl.Model.Entity;

namespace Mgi.Apl.Service
{
    public class ExportTemplate
    {
        public string TypeName { get; set; }
        /// <summary>
        /// 文件名前缀
        /// </summary>
        public string CnFileNamePrefix { get; set; }
        /// <summary>
        /// 英文下的文件名前缀
        /// </summary>
        public string EnFileNamePrefix { get; set; }
        public List<ExportHeader> Headers { get; set; }

        public static readonly ExportTemplate<MaterialBrand> MaterilBrandExportTemplate = new ExportTemplate<MaterialBrand>()
        {
            CnFileNamePrefix = "物料品牌",
            EnFileNamePrefix = "MaterialBrand",
            Headers = new List<ExportHeader>()
            {
                new ExportHeader()
                {
                     Field = "Code",
                     CnHeaderText = "编码",
                     EnHeaderText = "Code"
                },
                new ExportHeader()
                {
                     Field = "Name",
                     CnHeaderText = "名称",
                     EnHeaderText = "Name"
                },
                new ExportHeader()
                {
                    Field = "Desc",
                    CnHeaderText = "备注",
                    EnHeaderText = "Description"
                },
                new ExportHeader()
                {
                    Field = "ModifyTime",
                    CnHeaderText = "修改时间",
                    EnHeaderText = "Modify Time"
                }
            }
        };
        public static readonly ExportTemplate<MaterialCategory> MaterialCategoryExportTemplate = new ExportTemplate<MaterialCategory>()
        {
            CnFileNamePrefix = "物料类别",
            EnFileNamePrefix = "MaterialCategory",
            Headers = new List<ExportHeader>()
            {
                new ExportHeader()
                {
                     Field = "Code",
                     CnHeaderText = "编码",
                     EnHeaderText = "Code"
                },
                new ExportHeader()
                {
                     Field = "Name",
                     CnHeaderText = "名称",
                     EnHeaderText = "Name"
                },
                new ExportHeader()
                {
                     Field = "RequireContainer",
                     CnHeaderText = "需要容器",
                     EnHeaderText = "Require Container",
                },
                new ExportHeader()
                {
                     Field = "ManualPartNumber",
                     CnHeaderText = "自定义PN",
                     EnHeaderText = "Manual PartNumber",
                },
                new ExportHeader()
                {
                     Field = "RequireRack",
                     CnHeaderText = "适用料架",
                     EnHeaderText = "Rack",
                },
                new ExportHeader()
                {
                    Field = "Desc",
                    CnHeaderText = "备注",
                    EnHeaderText = "Description"
                },
                new ExportHeader()
                {
                    Field = "ModifyTime",
                    CnHeaderText = "修改时间",
                    EnHeaderText = "Modify Time"
                }
            }
        };
        public static readonly ExportTemplate<MaterialType> MaterialTypeExportTemplate = new ExportTemplate<MaterialType>()
        {
            CnFileNamePrefix = "物料类型",
            EnFileNamePrefix = "MaterialType",
            Headers = new List<ExportHeader>()
            {
                new ExportHeader()
                {
                     Field = "Code",
                     CnHeaderText = "编码",
                     EnHeaderText = "Code"
                },
                new ExportHeader()
                {
                     Field = "Name",
                     CnHeaderText = "名称",
                     EnHeaderText = "Name"
                },
                new ExportHeader()
                {
                    Field = "Desc",
                    CnHeaderText = "备注",
                    EnHeaderText = "Description"
                },
                new ExportHeader()
                {
                    Field = "ModifyTime",
                    CnHeaderText = "修改时间",
                    EnHeaderText = "Modify Time"
                }
            }
        };
        public static readonly ExportTemplate<Material> MaterialExportTemplate = new ExportTemplate<Material>()
        {
            CnFileNamePrefix = "物料列表",
            EnFileNamePrefix = "MaterialList",
            Headers = new List<ExportHeader>()
            {
                new ExportHeader()
                {
                    Field = "Name",
                    CnHeaderText = "名称",
                    EnHeaderText = "Name"
                },
                new ExportHeader()
                {
                    Field = "BrandName",
                    CnHeaderText = "品牌",
                    EnHeaderText = "Brand"
                },
                new ExportHeader()
                {
                    Field = "CategoryName",
                    CnHeaderText = "类别",
                    EnHeaderText = "Category"
                },
                new ExportHeader()
                {
                    Field = "TypeName",
                    CnHeaderText = "类型",
                    EnHeaderText = "Type"
                },
                new ExportHeader()
                {
                    Field = "PartNumber",
                    CnHeaderText = "PN码",
                    EnHeaderText = "PN"
                },
                new ExportHeader()
                {
                    Field = "ContainerPartNumber",
                    CnHeaderText = "容器PN",
                    EnHeaderText = "Container PartNumber"
                },
                new ExportHeader()
                {
                    Field = "RackPn",
                    CnHeaderText = "适用料架",
                    EnHeaderText = "Rack PN"
                },
                new ExportHeader()
                {
                    Field = "Configs",
                    CnHeaderText = "参数",
                    EnHeaderText = "Parameters"
                },
                new ExportHeader()
                {
                    Field = "ModifyTime",
                    CnHeaderText = "修改时间",
                    EnHeaderText = "Modify Time"
                },
                new ExportHeader()
                {
                    Field = "Detail",
                    CnHeaderText = "详情",
                    EnHeaderText = "Detail"
                },
                new ExportHeader()
                {
                    Field = "Desc",
                    CnHeaderText = "备注",
                    EnHeaderText = "Description"
                },
            }
        };
    }
    /// <summary>
    /// excel 导出模板
    /// </summary>
    public class ExportTemplate<T> : ExportTemplate
    {
        public ExportTemplate()
        {
            TypeName = typeof(T).Name;
        }
    }

    /// <summary>
    /// 导出表头
    /// </summary>
    public class ExportHeader
    {
        /// <summary>
        /// 实体属性名
        /// </summary>
        public string Field { get; set; }
        public string CnHeaderText { get; set; }
        public string EnHeaderText { get; set; }

        public Func<object, object> Formatter { get; set; }
    }
}
