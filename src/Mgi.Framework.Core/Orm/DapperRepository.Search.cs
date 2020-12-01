using Dapper;
using Mgi.Framework.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace MicroOrm.Dapper.Repositories
{
    /// <summary>
    ///     Base Repository
    /// </summary>
    public partial class DapperRepository<TEntity, PK>
        where TEntity : class
    {
        public PageResult<TEntity> Search(SearchArgs<TEntity> searchArgs, IDbTransaction transaction = null)
        {
            var arg = searchArgs ?? new SearchArgs<TEntity>();
            var queryResult = SqlGenerator.GetSearch(arg);
            var conn = transaction == null ? ConnectionManager.OpenSlave() : transaction.Connection;
            try
            {
                var data = conn.Query<TEntity>(queryResult.Item1.GetSql(), queryResult.Item1.Param, transaction);
                var total = conn.QuerySingle<int>(queryResult.Item2.GetSql(), queryResult.Item2.Param);
                return new PageResult<TEntity>()
                {
                    Items = data,
                    PageCount = (int)Math.Ceiling((decimal)total / arg.PageSize),
                    PageIndex = arg.PageIndex,
                    PageSize = arg.PageSize,
                    TotalRows = total
                };
            }
            finally
            {
                if (transaction == null)
                {
                    conn.Close();
                }
            }
        }

        public async Task<PageResult<TEntity>> SearchAsync(SearchArgs<TEntity> searchArgs, IDbTransaction transaction = null)
        {
            var arg = searchArgs ?? new SearchArgs<TEntity>();
            var queryResult = SqlGenerator.GetSearch(arg);
            var conn = transaction == null ? ConnectionManager.OpenSlave() : transaction.Connection;
            try
            {
                var data = await conn.QueryAsync<TEntity>(queryResult.Item1.GetSql(), queryResult.Item1.Param, transaction);
                var total = await conn.QuerySingleAsync<int>(queryResult.Item2.GetSql(), queryResult.Item2.Param);
                return new PageResult<TEntity>()
                {
                    Items = data,
                    PageCount = (int)Math.Ceiling((decimal)total / arg.PageSize),
                    PageIndex = arg.PageIndex,
                    PageSize = arg.PageSize,
                    TotalRows = total
                };
            }
            finally
            {
                if (transaction == null)
                {
                    conn.Close();
                }
            }
        }
    }
}
