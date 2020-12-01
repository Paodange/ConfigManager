using Mgi.Apl.Model;
using Mgi.Framework.Core;

namespace Mgi.Apl.Service
{

    public interface IBaseService<T, TBO, TDTO, PK>
    where T : class, new()
    where TBO : class, new()
    where TDTO : class, new()
    {
        TDTO GetById(PK id);
        PK Add(TBO entity);
        int Delete(PK id);
        int Update(TBO entity);
        PageResult<TDTO> Search(SearchArgs<T> searchArgs);

        /// <summary>
        ///  导出  返回文件guid
        /// </summary>
        /// <param name="locale">区域</param>
        /// <param name="exportTemplate">导出模板</param>
        /// <param name="searchArgs">查询条件</param>
        /// <returns></returns>
        string Export(string locale, ExportTemplate exportTemplate, SearchArgs<T> searchArgs);
    }
}
