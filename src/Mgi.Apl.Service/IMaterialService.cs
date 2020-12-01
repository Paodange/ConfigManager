using System.Collections.Generic;
using Mgi.Apl.Model.BO;
using Mgi.Apl.Model.DTO;
using Mgi.Apl.Model.Entity;
using Mgi.Framework.Core;

namespace Mgi.Apl.Service
{
    public interface IMaterialService : IBaseService<Material, MaterialBO, MaterialDTO, int?>
    {
        PageResult<IDictionary<string, object>> SearchDic(SearchArgs<Material> searchArgs);
        List<MaterialDTO> GetContainerMaterials(string pn);
        List<MaterialDTO> GetAllRacks();
        /// <summary>
        /// 备份到sql文件 并返回文件guid  通过guid下载备份的文件
        /// </summary>
        /// <returns></returns>
        string ExportToSql();
        void ImportFromSql(string sql);

        string ExportOfflinePackage();
    }
}
