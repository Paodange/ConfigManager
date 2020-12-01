using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using AutoMapper;
using Mgi.Apl.Model.BO;
using Mgi.Apl.Model.DTO;
using Mgi.Apl.Model.Entity;
using Mgi.Apl.Repository;
using Mgi.Framework.Core;
using Mgi.Framework.Core.ApiContract;
using Mgi.Framework.Util;
using Mgi.Framework.Util.Extention;
using MicroOrm.Dapper.Repositories;
using Microsoft.Extensions.PlatformAbstractions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Dapper;

namespace Mgi.Apl.Service.Impl
{
    public class MaterialService : AbstractService<Material, MaterialBO, MaterialDTO, int?>, IMaterialService
    {
        IMaterialSerialNoRepository SerialNoRepository { get; }
        IMaterialConfigRepository ConfigRepository { get; }
        IMaterialBrandRepository BrandRepository { get; }
        IMaterialTypeRepository MaterialTypeRepository { get; }
        IMaterialCategoryRepository MaterialCategoryRepository { get; }
        IMaterialCategoryService MaterialCategoryService { get; }
        IMaterialTypeService MaterialTypeService { get; }
        public MaterialService(
            IMapper mapper,
            IMaterialRepository repository,
            IMaterialConfigRepository configRepository,
            IMaterialBrandRepository brandRepository,
            IMaterialTypeRepository materialTypeRepository,
            IMaterialSerialNoRepository serialNoRepository,
            IMaterialCategoryRepository materialCategoryRepository,
            IMaterialCategoryService materialCategoryService,
            IMaterialTypeService materialTypeService,
            IAttachmentRepository attachmentRepository) : base(mapper, repository, attachmentRepository)
        {
            ConfigRepository = configRepository;
            BrandRepository = brandRepository;
            MaterialTypeRepository = materialTypeRepository;
            SerialNoRepository = serialNoRepository;
            MaterialCategoryRepository = materialCategoryRepository;
            MaterialCategoryService = materialCategoryService;
            MaterialTypeService = materialTypeService;
        }


        public override MaterialDTO GetById(int? id)
        {
            var materialDto = base.GetById(id);
            var typeDTO = MaterialTypeService.GetById(materialDto.TypeId);
            var materialConfigs = ConfigRepository.Find(x => x.MaterialId == materialDto.Id).OrderBy(x => x.Sort).ToList();
            var configs = typeDTO.Configs.Select(x => new MaterialConfigDTO()
            {
                ConfigKey = x.ConfigKey,
                ConfigKeyDesc = x.ConfigKeyDesc,
                ConfigValueType = x.ConfigValueType,
                ConfigValue = materialConfigs.FirstOrDefault(y => y.ConfigKey == x.ConfigKey) == null ? x.ConfigDefaultValue :
                    materialConfigs.FirstOrDefault(y => y.ConfigKey == x.ConfigKey).ConfigValue,
                MaterialId = materialDto.Id,
                Remark = x.Remark,
                Sort = x.Sort
            }).OrderBy(x => x.Sort).ToList();
            materialDto.Configs = configs;
            return materialDto;
        }

        public override int? Add(MaterialBO bo)
        {
            var type = MaterialTypeRepository.FindById(bo.TypeId);
            var category = MaterialCategoryRepository.FindById(bo.CategoryId);
            if (category.RequireContainer == true)
            {
                var material = Repository.FindById(bo.ContainerMaterialId);
                if (material == null)
                {
                    throw new BusinessException(ResponseCode.CannotFindMaterialById.Format(bo.ContainerMaterialId));
                }
                bo.ContainerPartNumber = material.PartNumber;
            }
            if (category.RequireRack == true)
            {
                var material = Repository.FindById(bo.RackId);
                if (material == null)
                {
                    throw new BusinessException(ResponseCode.CannotFindMaterialById.Format(bo.RackId));
                }
                bo.RackPn = material.PartNumber;
            }
            if (category.ManualPartNumber == true)  //手动输入PN
            {
                //判断用户输入的PN是否重复
                if (string.IsNullOrWhiteSpace(bo.PartNumber))
                {
                    throw new BusinessException(ResponseCode.PartNumberCannotBeNull);
                }
                else
                {
                    if (Repository.Count(x => x.PartNumber == bo.PartNumber) > 0)
                    {
                        throw new BusinessException(ResponseCode.PartNumberAlreadyExists.Format(bo.PartNumber));
                    }
                }
            }
            else
            {
                //自动生成PN
                var brand = BrandRepository.FindById(bo.BrandId);
                var serialNo = SerialNoRepository.SingleOrDefault(x => x.BrandCode == brand.Code && x.TypeCode == type.Code);
                var number = 1;
                if (serialNo == null)
                {
                    serialNo = new MaterialSerialNo() { BrandCode = brand.Code, TypeCode = type.Code, SerialNo = number };
                    serialNo.SerialNo++;
                    SerialNoRepository.Insert(serialNo);
                }
                else
                {
                    if (serialNo.SerialNo >= 99)
                    {
                        throw new BusinessException(ResponseCode.MaterialCountOverLimit);
                    }
                    number = serialNo.SerialNo;
                    serialNo.SerialNo++;
                    SerialNoRepository.Update(serialNo);
                }
                var pn = $"{brand.Code}{type.Code}{number.ToString().PadLeft(2, '0')}";
                bo.PartNumber = pn;
            }

            bo.CategoryId = type.CategoryId;
            bo.CategoryCode = category.Code;
            var id = base.Add(bo);
            if (bo.Configs != null && bo.Configs.Count > 0)
            {
                bo.Configs.AsParallel().ForAll(x => x.MaterialId = id);
                ConfigRepository.BulkInsert(Mapper.Map<List<MaterialConfig>>(bo.Configs));
            }
            return id;
        }

        public override int Update(MaterialBO bo)
        {
            var type = MaterialTypeRepository.FindById(bo.TypeId);
            var category = MaterialCategoryRepository.FindById(bo.CategoryId);
            if (category.RequireContainer == true)
            {
                var material = Repository.FindById(bo.ContainerMaterialId);
                if (material == null)
                {
                    throw new BusinessException(ResponseCode.CannotFindMaterialById.Format(bo.ContainerMaterialId));
                }
                bo.ContainerPartNumber = material.PartNumber;
            }
            if (category.RequireRack == true)
            {
                var material = Repository.FindById(bo.RackId);
                if (material == null)
                {
                    throw new BusinessException(ResponseCode.CannotFindMaterialById.Format(bo.RackId));
                }
                bo.RackPn = material.PartNumber;
            }
            bo.CategoryId = type.CategoryId;
            bo.CategoryCode = category.Code;
            if (bo.Configs != null && bo.Configs.Count > 0)
            {
                bo.Configs.AsParallel().ForAll(x => x.MaterialId = bo.Id);
                ConfigRepository.Delete(x => x.MaterialId == bo.Id);
                ConfigRepository.BulkInsert(Mapper.Map<List<MaterialConfig>>(bo.Configs));
            }
            return base.Update(bo);
        }

        public override int Delete(int? id)
        {
            ConfigRepository.Delete(x => x.Id == id);
            return base.Delete(id);
        }

        public override PageResult<MaterialDTO> Search(SearchArgs<Material> searchArgs)
        {
            var result = Mapper.Map<PageResult<MaterialDTO>>(Repository.Search(searchArgs));
            foreach (var item in result.Items)
            {
                item.Configs = Mapper.Map<List<MaterialConfigDTO>>(ConfigRepository.Find(x => x.MaterialId == item.Id));
            }
            return Mapper.Map<PageResult<MaterialDTO>>(result);
        }

        public PageResult<IDictionary<string, object>> SearchDic(SearchArgs<Material> searchArgs)
        {
            var result = Search(searchArgs);
            var list = new List<IDictionary<string, object>>();
            foreach (var item in result.Items)
            {
                var brand = BrandRepository.FindById(item.BrandId);
                var typeDTO = MaterialTypeService.GetById(item.TypeId);
                var materialConfigs = ConfigRepository.Find(x => x.MaterialId == item.Id).ToDictionary(x => x.ConfigKey);
                var configs = typeDTO.Configs.Select(x => new MaterialConfigDTO()
                {
                    ConfigKey = x.ConfigKey,
                    ConfigKeyDesc = x.ConfigKeyDesc,
                    ConfigValueType = x.ConfigValueType,
                    ConfigValue = materialConfigs.ContainsKey(x.ConfigKey) ? materialConfigs[x.ConfigKey].ConfigValue : x.ConfigDefaultValue,
                    MaterialId = item.Id,
                    Remark = x.Remark,
                    Sort = x.Sort
                }).ToList();
                item.Configs = configs;
                item.BrandName = brand.Name;
                item.CategoryId = typeDTO.CategoryId;
                item.CategoryName = typeDTO.CategoryName;
                item.TypeName = typeDTO.Name;
                var dic = item.ToDictionary();
                foreach (var c in item.Configs)
                {
                    dic.Add(c.ConfigKey, c.ConfigValue);
                }
                list.Add(dic);
            }
            var p = new PageResult<IDictionary<string, object>>()
            {
                Items = list,
                PageCount = result.PageCount,
                PageIndex = result.PageIndex,
                PageSize = result.PageSize,
                TotalRows = result.TotalRows
            };
            return p;
        }

        public List<MaterialDTO> GetContainerMaterials(string pn)
        {
            return Mapper.Map<List<MaterialDTO>>(
                Repository.Find(x =>
                       x.CategoryCode == "Consumable" && x.PartNumber.Contains(pn)
            ));
        }

        public List<MaterialDTO> GetAllRacks()
        {
            return Mapper.Map<List<MaterialDTO>>(
               Repository.Find(x => x.CategoryCode == "Rack")).OrderBy(x => x.PartNumber).ToList();
        }


        public string ExportOfflinePackage()
        {
            var webRootPath = PlatformServices.Default.Application.ApplicationBasePath;
            var dir = Path.Combine(webRootPath, "files", "export");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            var result = SearchDic(new SearchArgs<Material>() { Pagination = false });
            var fileName = $"MaterialConfig_{DateTime.Now.ToString("yyyyMMddHHmmss")}.json";
            var filePath = Path.Combine(dir, fileName);
            Attachment attachment = null;
            if (File.Exists(filePath))
            {
                attachment = AttachmentRepository.SingleOrDefault(x => x.OrginalFileName == fileName);
                if (attachment != null)
                {
                    attachment.DownloadTimes++;
                    return attachment.FileGuid;
                }
            }
            var dic = result.Items.ToDictionary(item => (string)item["PartNumber"]);
            var s = JsonUtil.Serialize(dic, prettify: true);
            File.WriteAllText(filePath, s, Encoding.UTF8);
            var md5 = MD5Util.MD5Stream(filePath);
            var size = new FileInfo(filePath).Length;
            attachment = new Attachment()
            {
                Type = "export",
                ContentType = "application/json",
                DownloadTimes = 0,
                FileExtention = ".json",
                FileName = fileName,
                OrginalFileName = "MaterialConfig.json",
                MD5 = md5,
                Size = size,
            };
            var user = GetUserIdentity();
            if (user != null)
            {
                attachment.CreateTime = DateTime.Now;
                attachment.CreateUserName = user.UserName;
                attachment.ModifyTime = DateTime.Now;
                attachment.ModifyUserName = user.UserName;
            }
            AttachmentRepository.Insert(attachment);
            return attachment.FileGuid;
        }

        public string ExportToSql()
        {
            var webRootPath = PlatformServices.Default.Application.ApplicationBasePath;
            var dir = Path.Combine(webRootPath, "files", "export");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string fileName = $"BackupMaterial_{DateTime.Now.ToString("yyyyMMddHHmmss")}.bak";
            var filePath = Path.Combine(dir, fileName);
            #region 生成sql
            var builder = new StringBuilder();
            builder.AppendLine($"------------Generate by APL-WEB {DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}-----------------");
            builder.AppendLine("---------------------------clear existing data begin---------------------------");
            builder.AppendLine("truncate table \"public\".\"material\";");
            builder.AppendLine("truncate table \"public\".\"material_brand\";");
            builder.AppendLine("truncate table \"public\".\"material_category\";");
            builder.AppendLine("truncate table \"public\".\"material_category_config\";");
            builder.AppendLine("truncate table \"public\".\"material_config\";");
            builder.AppendLine("truncate table \"public\".\"material_serial_no\";");
            builder.AppendLine("truncate table \"public\".\"material_type\";");
            builder.AppendLine("truncate table \"public\".\"material_type_config\";");
            builder.AppendLine("---------------------------clear existing data end---------------------------");

            //物料表
            builder.AppendLine(GenerateInsertSql<Material>());
            //品牌表
            builder.AppendLine(GenerateInsertSql<MaterialBrand>());
            //物料类别表
            builder.AppendLine(GenerateInsertSql<MaterialCategory>());
            //物料类别参数配置表
            builder.AppendLine(GenerateInsertSql<MaterialCategoryConfig>());
            //物料参数配置
            builder.AppendLine(GenerateInsertSql<MaterialConfig>());
            //PN序号配置
            builder.AppendLine(GenerateInsertSql<MaterialSerialNo>());
            //物料类型表
            builder.AppendLine(GenerateInsertSql<MaterialType>());
            //物料类型参数表
            builder.AppendLine(GenerateInsertSql<MaterialTypeConfig>());

            //更新序列
            builder.AppendLine("---------------------------update serial begin---------------------------");
            var conn = ConnectionManager.OpenMaster();

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "select 'material_brand' as \"table_name\",COALESCE(max(id),0)+1 as \"max_id\" from material_brand union all \r\n" +
                                 @"select 'material_category_config',COALESCE(max(id),0)+1 from material_category_config union all
                                       select 'material_category',COALESCE(max(id),0)+1 from material_category union all
                                       select 'material_config',COALESCE(max(id),0)+1 from material_config union all
                                       select 'material',COALESCE(max(id),0)+1 from material union all
                                       select 'material_serial_no',COALESCE(max(id),0)+1 from material_serial_no union all
                                       select 'material_type_config',COALESCE(max(id),0)+1 from material_type_config union all
                                       select 'material_type',COALESCE(max(id),0)+1 from material_type union all
                                       select 'sys_lookup',COALESCE(max(id),0)+1 from sys_lookup; ";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    builder.AppendLine($"alter sequence {reader.GetString(0)}_id_seq restart with {reader.GetInt32(1)};");
                }
            }
            conn.Close();
            builder.AppendLine("---------------------------update serial end---------------------------");
            #endregion
            var s = Convert.ToBase64String(Encoding.UTF8.GetBytes(builder.ToString()));
            File.WriteAllText(filePath, s, Encoding.UTF8);
            var md5 = MD5Util.MD5Stream(filePath);
            var size = new FileInfo(filePath).Length;
            var attachment = new Attachment()
            {
                Type = "export",
                ContentType = "application/octet-stream",
                DownloadTimes = 0,
                FileExtention = ".bak",
                FileName = fileName,
                OrginalFileName = fileName,
                MD5 = md5,
                Size = size,
            };
            var user = GetUserIdentity();
            if (user != null)
            {
                attachment.CreateTime = DateTime.Now;
                attachment.CreateUserName = user.UserName;
                attachment.ModifyTime = DateTime.Now;
                attachment.ModifyUserName = user.UserName;
            }
            AttachmentRepository.Insert(attachment);
            return attachment.FileGuid;
        }

        public void ImportFromSql(string sql)
        {
            var conn = ConnectionManager.OpenMaster();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }


        protected override IWorkbook CreateExcelWorkBook(string locale, ExportTemplate exportTemplate, SearchArgs<Material> searchArgs)
        {
            IWorkbook workbook = new XSSFWorkbook();
            //导出当前页
            if (searchArgs.Pagination && searchArgs.Model != null && searchArgs.Model.CategoryId.HasValue)
            {
                var result = SearchDic(searchArgs);
                var category = MaterialCategoryService.GetById(searchArgs.Model.CategoryId);
                CreateSingleSheet(workbook, category, locale, "Sheet1", exportTemplate, result);
                return workbook;
            }
            //导出所有
            else
            {
                //先获取类别  每个类别创建一个Sheet
                var categories = MaterialCategoryService.Search(new SearchArgs<MaterialCategory> { Pagination = false }).Items;
                foreach (var category in categories)
                {
                    var result = SearchDic(new SearchArgs<Material>() { Model = new Material() { CategoryId = category.Id } });
                    CreateSingleSheet(workbook, category, locale,
                        "en-us".EqualsIgnoreCase(locale) ? category.Code : category.Name, exportTemplate, result);
                }
            }
            return workbook;
        }

        /// <summary>
        /// 创建单个Sheet
        /// </summary>
        /// <returns></returns>
        private void CreateSingleSheet(IWorkbook workbook, MaterialCategoryDTO category, string locale, string sheetName, ExportTemplate template, PageResult<IDictionary<string, object>> result)
        {
            ISheet sheet = workbook.CreateSheet(sheetName);
            var row = sheet.CreateRow(0);
            var exportFields = template.Headers.Select(y => y.Field).ToList();
            int k = 0;
            int columnIndex = 0;
            for (int i = 0; i < exportFields.Count; i++)
            {
                if (exportFields[i].Equals("Configs"))  //配置参数
                {
                    for (k = 0; k < category.Configs.Count; k++)
                    {
                        var cell = row.CreateCell(columnIndex + k, CellType.String);
                        cell.SetCellValue("en-us".EqualsIgnoreCase(locale) ?
                            category.Configs[k].ConfigKey : category.Configs[k].ConfigKeyDesc); //表头
                        columnIndex++;
                    }
                }
                else
                {
                    if (IsSheetColumnShow(category, exportFields[i]))
                    {
                        var cell = row.CreateCell(columnIndex + (k > 0 ? k - 1 : k), CellType.String);
                        var header = template.Headers.FirstOrDefault(x => x.Field.Equals(exportFields[i]));
                        cell.SetCellValue("en-us".EqualsIgnoreCase(locale) ? header.EnHeaderText : header.CnHeaderText); //表头
                        columnIndex++;
                    }
                }
            }

            for (int i = 1; i < result.Items.Count() + 1; i++)
            {
                k = 0;
                row = sheet.CreateRow(i);
                columnIndex = 0;
                for (int j = 0; j < exportFields.Count; j++)
                {
                    if (exportFields[j].Equals("Configs"))  //配置参数
                    {
                        for (k = 0; k < category.Configs.Count; k++)
                        {
                            var cell = row.CreateCell(columnIndex + k, CellType.String);
                            cell.SetCellValue(result.Items.ElementAt(i - 1)[category.Configs[k].ConfigKey]?.ToString());
                            columnIndex++;
                        }
                    }
                    else
                    {
                        if (IsSheetColumnShow(category, exportFields[j]))
                        {
                            var cell = row.CreateCell(columnIndex + (k > 0 ? k - 1 : k), CellType.String);
                            cell.SetCellValue(result.Items.ElementAt(i - 1)[exportFields[j]]?.ToString());
                            columnIndex++;
                        }
                    }
                }
            }
        }

        /// <summary>
        ///  过滤掉有些sheet 不需要显示的列
        /// </summary>
        /// <param name="category"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        private bool IsSheetColumnShow(MaterialCategoryDTO category, string field)
        {
            if (field == "ContainerPartNumber" && true != category.RequireContainer)  //有可能是null
            {
                return false;
            }
            if (field == "RackPn" && true != category.RequireRack)//有可能是null
            {
                return false;
            }
            return true;
        }

        private string GenerateInsertSql<T>() where T : class
        {
            var builder = new StringBuilder();
            var type = typeof(T);
            var tableAttr = type.GetCustomAttribute<TableAttribute>();
            string tableName = tableAttr == null ? type.Name : tableAttr.Name;
            builder.AppendLine($"-------------------records of {tableName} begin---------------------");
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            using (var conn = ConnectionManager.OpenMaster())
            {
                var data = conn.Query($"SELECT * FROM {tableName}");

                if (data.Count() > 0)
                {
                    Dictionary<string, PropertyInfo> columns = new Dictionary<string, PropertyInfo>();
                    foreach (var property in properties)
                    {
                        var colAttr = property.GetCustomAttribute<ColumnAttribute>();
                        if (colAttr != null)
                        {
                            columns.Add("\"" + colAttr.Name + "\"", property);
                        }
                    }
                    var colString = string.Join(",", columns.Keys);
                    foreach (var row in data)
                    {
                        var dic = (IDictionary<string, object>)row;
                        builder.Append($"insert into \"{tableName}\"({colString}) values(");
                        foreach (var p in columns.Keys)
                        {
                            builder.Append(FormatValue(dic[p])).Append(",");
                        }
                        builder.Remove(builder.Length - 1, 1).AppendLine(");");
                    }
                }
            }
            builder.AppendLine($"-------------------records of {tableName} end---------------------");
            return builder.ToString();

        }

        private string FormatValue(object value)
        {
            if (value == null)
            {
                return "NULL";
            }
            if (value is DateTime d)
            {
                return $"'{d.ToString("yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture)}'";
            }
            else if (value is ValueType)
            {
                return $"{value}";
            }
            else
            {
                return $"'{value}'";
            }
        }
    }
}
