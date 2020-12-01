using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using AutoMapper;
using Mgi.Apl.Model;
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

namespace Mgi.Apl.Service
{
    public abstract class AbstractService<T, TBO, TDTO, PK> : IBaseService<T, TBO, TDTO, PK>
        where T : class, new()
        where TBO : class, new()
        where TDTO : class, new()
    {
        public IMapper Mapper { get; }
        public IDapperRepository<T, PK> Repository { get; }

        public IAttachmentRepository AttachmentRepository { get; set; }
        public AbstractService(IMapper mapper, IDapperRepository<T, PK> repository, IAttachmentRepository attachmentRepository)
        {
            Mapper = mapper;
            Repository = repository;
            AttachmentRepository = attachmentRepository;
        }
        public virtual TDTO GetById(PK id)
        {
            return Mapper.Map<TDTO>(Repository.FindById(id));
        }
        public virtual PK Add(TBO bo)
        {
            T entity = Mapper.Map<T>(bo);
            if (entity is EditableModel<PK> em)
            {
                FillEditableModel(em, true);
            }
            return Repository.InsertGetId(entity);
        }

        public virtual int AddMany(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                if (entity is EditableModel<PK> em)
                {
                    FillEditableModel(em, true);
                }
            }
            return Repository.BulkInsert(entities);
        }

        public virtual int Delete(PK id)
        {
            return Repository.DeleteById(id);
        }

        public virtual PageResult<TDTO> Search(SearchArgs<T> searchArgs)
        {
            var result = Repository.Search(searchArgs);

            return new PageResult<TDTO>()
            {
                Items = Mapper.Map<IEnumerable<TDTO>>(result.Items),
                PageCount = result.PageCount,
                PageIndex = result.PageIndex,
                PageSize = result.PageSize,
                TotalRows = result.TotalRows
            };
        }

        public virtual int Update(TBO bo)
        {
            T entity = Mapper.Map<T>(bo);
            if (entity is EditableModel<PK> em)
            {
                FillEditableModel(em, false);
            }
            return Repository.Update((T)entity);
        }



        public virtual string Export(string locale, ExportTemplate exportTemplate, SearchArgs<T> searchArgs)
        {
            var webRootPath = PlatformServices.Default.Application.ApplicationBasePath;
            var dir = Path.Combine(webRootPath, "files", "export");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string fileNamePrefix = "en-us".EqualsIgnoreCase(locale) ?
                    exportTemplate.EnFileNamePrefix : exportTemplate.CnFileNamePrefix;
            string fileName = $"{fileNamePrefix}_{DateTime.Now.ToStringIgnoreCulture("yyyyMMddHHmmss")}.xlsx";
            var filePath = Path.Combine(dir, fileName);
            if (File.Exists(filePath))
            {
                var attachment = AttachmentRepository.SingleOrDefault(x => x.OrginalFileName == fileName);
                if (attachment != null)
                {
                    attachment.DownloadTimes++;
                    AttachmentRepository.Update(attachment);
                    return attachment.FileGuid;
                }
            }
            IWorkbook workbook = CreateExcelWorkBook(locale, exportTemplate, searchArgs);
            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(stream);
                var md5 = MD5Util.MD5Stream(filePath);
                var size = new FileInfo(filePath).Length;
                Attachment attachment = new Attachment()
                {
                    Type = "export",
                    ContentType = "application/vnd.ms-excel",
                    DownloadTimes = 0,
                    FileExtention = ".xlsx",
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
        }
        protected virtual IWorkbook CreateExcelWorkBook(string locale, ExportTemplate exportTemplate, SearchArgs<T> searchArgs)
        {
            var result = Search(searchArgs);
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Sheet1");
            var row = sheet.CreateRow(0);
            var exportProperties = typeof(TDTO).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var exportFields = exportTemplate.Headers.Select(y => y.Field).ToList();
            for (int i = 0; i < exportFields.Count; i++)
            {
                var header = exportTemplate.Headers.FirstOrDefault(x => x.Field.Equals(exportFields[i]));
                var cell = row.CreateCell(i, CellType.String);
                cell.SetCellValue("en-us".EqualsIgnoreCase(locale) ? header.EnHeaderText : header.CnHeaderText); //表头
            }
            for (int i = 1; i < result.Items.Count() + 1; i++)
            {
                row = sheet.CreateRow(i);
                for (int j = 0; j < exportFields.Count; j++)
                {
                    var cell = row.CreateCell(j, CellType.String);
                    var value = exportProperties.FirstOrDefault(x => x.Name == exportFields[j])?.GetValue(result.Items.ElementAt(i - 1));
                    var header = exportTemplate.Headers.FirstOrDefault(x => x.Field.Equals(exportFields[j]));
                    if (header.Formatter != null)
                    {
                        value = header.Formatter(value);
                    }
                    cell.SetCellValue(value?.ToString());
                }
            }
            return workbook;
        }
        protected virtual void FillEditableModel(EditableModel<PK> em, bool isInsert)
        {
            var userIdentity = Thread.CurrentPrincipal.Identity as IUserIdentity;
            if (isInsert)
            {
                em.CreateTime = DateTime.Now;
                em.CreateUserId = userIdentity.UserId;
                em.CreateUserName = userIdentity.RealName;
            }
            em.ModifyTime = DateTime.Now;
            em.ModifyUserId = userIdentity.UserId;
            em.ModifyUserName = userIdentity.RealName;
        }
        protected IUserIdentity GetUserIdentity()
        {
            return Thread.CurrentPrincipal?.Identity as IUserIdentity;
        }
    }
}
