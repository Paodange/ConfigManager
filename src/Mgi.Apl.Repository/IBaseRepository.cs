using Mgi.Framework.Core;
using System.Collections.Generic;
using System.Data;

namespace Mgi.Apl.Repository
{
    /// <summary>
    /// 通用增删改查仓储层接口
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="PK">主键类型</typeparam>
    public interface IBaseRepository<T, PK> where T : class
    {
        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        int Insert(T entity, IDbTransaction transaction = null);
        /// <summary>
        /// 插入多条记录
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        int Insert(IEnumerable<T> entities, IDbTransaction transaction = null);
        /// <summary>
        /// 插入并返回数据库生成的Id
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        PK InsertGetId(T entity, IDbTransaction transaction = null);
        /// <summary>
        /// 插入并返回实体对象，如果有数据库填充的字段  则可以使用此方法
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        T InsertGetEntity(T entity, IDbTransaction transaction = null);
        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        T FindById(PK id, IDbTransaction transaction = null);
        /// <summary>
        /// 根据指定条件查询
        /// </summary>
        /// <param name="condition">条件</param>
        /// <param name="param">条件参数</param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        IEnumerable<T> Find(string condition, object param, IDbTransaction transaction = null);
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="searchArgs">搜索参数</param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        PageResult<T> Search(SearchArgs<T> searchArgs, IDbTransaction transaction = null);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        int Update(T entity, IDbTransaction transaction = null);
        /// <summary>
        /// 对指定条件的记录批量更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="condition"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        int Update(T entity, string condition, object param, IDbTransaction transaction = null);
        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        int DeleteById(PK id, IDbTransaction transaction = null);
        /// <summary>
        /// 根据指定条件删除
        /// </summary>
        /// <param name="condition">条件</param>
        /// <param name="param">条件参数</param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        int Delete(string condition, object param, IDbTransaction transaction = null);

    }
}
