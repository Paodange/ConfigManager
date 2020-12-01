using System;
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
        public virtual int Update(TEntity instance)
        {
            return Update(instance, null);
        }

        /// <inheritdoc />
        public virtual int Update(TEntity instance, IDbTransaction transaction)
        {
            var sqlQuery = SqlGenerator.GetUpdate(instance);
            if (transaction == null)
            {
                using (var conn = ConnectionManager.OpenMaster())
                {
                    return conn.Execute(sqlQuery.GetSql(), instance, transaction);
                }
            }
            return transaction.Connection.Execute(sqlQuery.GetSql(), instance, transaction);
        }

        /// <inheritdoc />
        public virtual Task<int> UpdateAsync(TEntity instance)
        {
            return UpdateAsync(instance, null);
        }

        /// <inheritdoc />
        public virtual async Task<int> UpdateAsync(TEntity instance, IDbTransaction transaction)
        {
            var sqlQuery = SqlGenerator.GetUpdate(instance);
            if (transaction == null)
            {
                using (var conn = ConnectionManager.OpenMaster())
                {
                    return await conn.ExecuteAsync(sqlQuery.GetSql(), instance, transaction);
                }
            }
            return await transaction.Connection.ExecuteAsync(sqlQuery.GetSql(), instance, transaction);
        }

        /// <inheritdoc />
        public virtual int Update(Expression<Func<TEntity, bool>> predicate, TEntity instance)
        {
            return Update(predicate, instance, null);
        }

        /// <inheritdoc />
        public virtual int Update(Expression<Func<TEntity, bool>> predicate, TEntity instance, IDbTransaction transaction)
        {
            var sqlQuery = SqlGenerator.GetUpdate(predicate, instance);
            if (transaction == null)
            {
                using (var conn = ConnectionManager.OpenMaster())
                {
                    return conn.Execute(sqlQuery.GetSql(), sqlQuery.Param, transaction);
                }
            }
            return transaction.Connection.Execute(sqlQuery.GetSql(), sqlQuery.Param, transaction);
        }

        /// <inheritdoc />
        public virtual Task<int> UpdateAsync(Expression<Func<TEntity, bool>> predicate, TEntity instance)
        {
            return UpdateAsync(predicate, instance, null);
        }

        /// <inheritdoc />
        public virtual async Task<int> UpdateAsync(Expression<Func<TEntity, bool>> predicate, TEntity instance, IDbTransaction transaction)
        {
            var sqlQuery = SqlGenerator.GetUpdate(predicate, instance);
            if (transaction == null)
            {
                using (var conn = ConnectionManager.OpenMaster())
                {
                    return await conn.ExecuteAsync(sqlQuery.GetSql(), sqlQuery.Param, transaction);
                }
            }
            return await transaction.Connection.ExecuteAsync(sqlQuery.GetSql(), sqlQuery.Param, transaction);
        }
    }
}
