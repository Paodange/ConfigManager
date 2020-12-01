using System.Data;
using System.Threading.Tasks;
using Dapper;
using Mgi.Framework.Core;

namespace MicroOrm.Dapper.Repositories
{
    /// <summary>
    ///     Base Repository
    /// </summary>
    public partial class DapperRepository<TEntity, PK>
        where TEntity : class
    {
        /// <inheritdoc />
        public virtual TEntity FindById(object id)
        {
            return FindById(id, null);
        }

        /// <inheritdoc />
        public virtual TEntity FindById(object id, IDbTransaction transaction)
        {
            var queryResult = SqlGenerator.GetSelectById(id);
            var conn = transaction == null ? ConnectionManager.OpenSlave() : transaction.Connection;
            try
            {
                return conn.QuerySingleOrDefault<TEntity>(queryResult.GetSql(), queryResult.Param, transaction);
            }
            finally
            {
                if (transaction == null)
                {
                    conn.Close();
                }
            }
        }

        /// <inheritdoc />
        public virtual Task<TEntity> FindByIdAsync(object id)
        {
            return FindByIdAsync(id, null);
        }

        /// <inheritdoc />
        public virtual Task<TEntity> FindByIdAsync(object id, IDbTransaction transaction)
        {
            var queryResult = SqlGenerator.GetSelectById(id);
            var conn = transaction == null ? ConnectionManager.OpenSlave() : transaction.Connection;
            try
            {
                return conn.QuerySingleOrDefaultAsync<TEntity>(queryResult.GetSql(), queryResult.Param, transaction);
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
