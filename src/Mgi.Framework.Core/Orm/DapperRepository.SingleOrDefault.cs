using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
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
        public virtual TEntity SingleOrDefault()
        {
            return SingleOrDefault(null, null);
        }

        /// <inheritdoc />
        public virtual TEntity SingleOrDefault(IDbTransaction transaction)
        {
            return SingleOrDefault(null, transaction);
        }

        /// <inheritdoc />
        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return SingleOrDefault(predicate, null);
        }

        /// <inheritdoc />
        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction)
        {
            var queryResult = SqlGenerator.GetSelectFirst(predicate);
            if (transaction == null)
            {
                using (var conn = ConnectionManager.OpenSlave())
                {
                    return conn.QueryFirstOrDefault<TEntity>(queryResult.GetSql(), queryResult.Param, transaction);
                }
            }
            return transaction.Connection.QueryFirstOrDefault<TEntity>(queryResult.GetSql(), queryResult.Param, transaction);
        }

        /// <inheritdoc />
        public virtual Task<TEntity> SingleOrDefaultAsync()
        {
            return SingleOrDefaultAsync(null, null);
        }

        /// <inheritdoc />
        public virtual Task<TEntity> SingleOrDefaultAsync(IDbTransaction transaction)
        {
            return SingleOrDefaultAsync(null, transaction);
        }

        /// <inheritdoc />
        public virtual Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return SingleOrDefaultAsync(predicate, null);
        }

        /// <inheritdoc />
        public virtual Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction)
        {
            var queryResult = SqlGenerator.GetSelectFirst(predicate);
            if (transaction == null)
            {
                using (var conn = ConnectionManager.OpenSlave())
                {
                    return conn.QueryFirstOrDefaultAsync<TEntity>(queryResult.GetSql(), queryResult.Param, transaction);
                }
            }
            return transaction.Connection.QueryFirstOrDefaultAsync<TEntity>(queryResult.GetSql(), queryResult.Param, transaction);
        }
    }
}
