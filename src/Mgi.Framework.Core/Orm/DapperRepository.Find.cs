using System;
using System.Collections.Generic;
using System.Data;
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
        public virtual IEnumerable<TEntity> Find(IDbTransaction transaction = null)
        {
            return Find(null, transaction);
        }

        /// <inheritdoc />
        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction = null)
        {
            var queryResult = SqlGenerator.GetSelectAll(predicate);
            var conn = transaction == null ? ConnectionManager.OpenMaster() : transaction.Connection;
            try
            {
                return conn.Query<TEntity>(queryResult.GetSql(), queryResult.Param, transaction);
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
        public virtual Task<IEnumerable<TEntity>> FindAsync(IDbTransaction transaction = null)
        {
            return FindAsync(null, transaction);
        }

        /// <inheritdoc />
        public virtual Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction = null)
        {
            var queryResult = SqlGenerator.GetSelectAll(predicate);
            var conn = transaction == null ? ConnectionManager.OpenMaster() : transaction.Connection;
            try
            {
                return conn.QueryAsync<TEntity>(queryResult.GetSql(), queryResult.Param, transaction);
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
