using Dapper;
using Mgi.Framework.Core;
using System;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MicroOrm.Dapper.Repositories
{
    /// <inheritdoc />
    /// <summary>
    ///     Base Repository
    /// </summary>
    public partial class DapperRepository<TEntity, PK>
        where TEntity : class
    {
        /// <inheritdoc />
        public virtual int Count()
        {
            return Count(transaction: null);
        }

        /// <inheritdoc />
        public virtual int Count(IDbTransaction transaction)
        {
            return Count(null, transaction);
        }

        /// <inheritdoc />
        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return Count(predicate, transaction: null);
        }

        /// <inheritdoc />
        public virtual int Count(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction)
        {
            var queryResult = SqlGenerator.GetCount(predicate);
            var conn = transaction == null ? ConnectionManager.OpenSlave() : transaction.Connection;
            try
            {
                return conn.QueryFirstOrDefault<int>(queryResult.GetSql(), queryResult.Param, transaction);
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
        public virtual int Count(Expression<Func<TEntity, object>> distinctField)
        {
            return Count(distinctField, null);
        }

        /// <inheritdoc />
        public virtual int Count(Expression<Func<TEntity, object>> distinctField, IDbTransaction transaction)
        {
            return Count(null, distinctField, transaction);
        }

        /// <inheritdoc />
        public virtual int Count(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> distinctField)
        {
            return Count(predicate, distinctField, null);
        }

        /// <inheritdoc />
        public virtual int Count(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> distinctField, IDbTransaction transaction)
        {
            var queryResult = SqlGenerator.GetCount(predicate, distinctField);
            var conn = transaction == null ? ConnectionManager.OpenSlave() : transaction.Connection;
            try
            {
                return conn.QueryFirstOrDefault<int>(queryResult.GetSql(), queryResult.Param, transaction);
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
        public virtual Task<int> CountAsync()
        {
            return CountAsync(transaction: null);
        }

        /// <inheritdoc />
        public virtual Task<int> CountAsync(IDbTransaction transaction)
        {
            return CountAsync(null, transaction);
        }

        /// <inheritdoc />
        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return CountAsync(predicate, transaction: null);
        }

        /// <inheritdoc />
        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction)
        {
            var queryResult = SqlGenerator.GetCount(predicate);
            var conn = transaction == null ? ConnectionManager.OpenSlave() : transaction.Connection;
            try
            {
                return conn.QueryFirstOrDefaultAsync<int>(queryResult.GetSql(), queryResult.Param, transaction);
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
        public virtual Task<int> CountAsync(Expression<Func<TEntity, object>> distinctField)
        {
            return CountAsync(distinctField, null);
        }

        /// <inheritdoc />
        public virtual Task<int> CountAsync(Expression<Func<TEntity, object>> distinctField, IDbTransaction transaction)
        {
            return CountAsync(null, distinctField, transaction);
        }

        /// <inheritdoc />
        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> distinctField)
        {
            return CountAsync(predicate, distinctField, null);
        }

        /// <inheritdoc />
        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> distinctField, IDbTransaction transaction)
        {
            var queryResult = SqlGenerator.GetCount(predicate, distinctField);
            var conn = transaction == null ? ConnectionManager.OpenSlave() : transaction.Connection;
            try
            {
                return conn.QueryFirstOrDefaultAsync<int>(queryResult.GetSql(), queryResult.Param, transaction);
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