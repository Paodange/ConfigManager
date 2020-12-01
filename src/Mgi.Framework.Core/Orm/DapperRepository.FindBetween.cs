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
        private const string _dateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        /// <inheritdoc />
        public IEnumerable<TEntity> FindBetween(object from, object to, Expression<Func<TEntity, object>> btwField)
        {
            return FindBetween(from, to, btwField, transaction: null);
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> FindBetween(object from, object to, Expression<Func<TEntity, object>> btwField, IDbTransaction transaction)
        {
            return FindBetween(from, to, btwField, null, transaction);
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> FindBetween(DateTime from, DateTime to, Expression<Func<TEntity, object>> btwField)
        {
            return FindBetween(from, to, btwField, transaction: null);
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> FindBetween(DateTime from, DateTime to, Expression<Func<TEntity, object>> btwField, IDbTransaction transaction)
        {
            return FindBetween(from, to, btwField, null, transaction);
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> FindBetween(DateTime from, DateTime to, Expression<Func<TEntity, object>> btwField, Expression<Func<TEntity, bool>> predicate)
        {
            return FindBetween(from, to, btwField, predicate, null);
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> FindBetween(
            DateTime from,
            DateTime to,
            Expression<Func<TEntity, object>> btwField,
            Expression<Func<TEntity, bool>> predicate,
            IDbTransaction transaction)
        {
            var fromString = from.ToString(_dateTimeFormat);
            var toString = to.ToString(_dateTimeFormat);
            return FindBetween(fromString, toString, btwField, predicate, transaction);
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> FindBetween(object from, object to, Expression<Func<TEntity, object>> btwField, Expression<Func<TEntity, bool>> predicate)
        {
            return FindBetween(from, to, btwField, predicate, null);
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> FindBetween(
            object from,
            object to,
            Expression<Func<TEntity, object>> btwField,
            Expression<Func<TEntity, bool>> predicate,
            IDbTransaction transaction)
        {
            var queryResult = SqlGenerator.GetSelectBetween(from, to, btwField, predicate);
            if (transaction == null)
            {
                using (var conn = ConnectionManager.OpenSlave())
                {
                    return conn.Query<TEntity>(queryResult.GetSql(), queryResult.Param, transaction);
                }
            }
            return transaction.Connection.Query<TEntity>(queryResult.GetSql(), queryResult.Param, transaction);
        }

        /// <inheritdoc />
        public Task<IEnumerable<TEntity>> FindAllBetweenAsync(object from, object to, Expression<Func<TEntity, object>> btwField)
        {
            return FindAllBetweenAsync(from, to, btwField, transaction: null);
        }

        /// <inheritdoc />
        public Task<IEnumerable<TEntity>> FindAllBetweenAsync(object from, object to, Expression<Func<TEntity, object>> btwField, IDbTransaction transaction)
        {
            return FindAllBetweenAsync(from, to, btwField, null, transaction);
        }

        /// <inheritdoc />
        public Task<IEnumerable<TEntity>> FindAllBetweenAsync(DateTime from, DateTime to, Expression<Func<TEntity, object>> btwField)
        {
            return FindAllBetweenAsync(from, to, btwField, transaction: null);
        }

        /// <inheritdoc />
        public Task<IEnumerable<TEntity>> FindAllBetweenAsync(DateTime from, DateTime to, Expression<Func<TEntity, object>> btwField, IDbTransaction transaction)
        {
            return FindAllBetweenAsync(from, to, btwField, null, transaction);
        }

        /// <inheritdoc />
        public Task<IEnumerable<TEntity>> FindAllBetweenAsync(DateTime from, DateTime to, Expression<Func<TEntity, object>> btwField, Expression<Func<TEntity, bool>> predicate)
        {
            return FindAllBetweenAsync(from, to, btwField, predicate, null);
        }

        /// <inheritdoc />
        public Task<IEnumerable<TEntity>> FindAllBetweenAsync(object from, object to, Expression<Func<TEntity, object>> btwField, Expression<Func<TEntity, bool>> predicate)
        {
            return FindAllBetweenAsync(from, to, btwField, predicate, null);
        }

        /// <inheritdoc />
        public Task<IEnumerable<TEntity>> FindAllBetweenAsync(
            DateTime from,
            DateTime to,
            Expression<Func<TEntity, object>> btwField,
            Expression<Func<TEntity, bool>> predicate,
            IDbTransaction transaction)
        {
            return FindAllBetweenAsync(from.ToString(_dateTimeFormat), to.ToString(_dateTimeFormat), btwField, predicate, transaction);
        }

        /// <inheritdoc />
        public Task<IEnumerable<TEntity>> FindAllBetweenAsync(
            object from,
            object to,
            Expression<Func<TEntity, object>> btwField,
            Expression<Func<TEntity, bool>> predicate,
            IDbTransaction transaction)
        {
            var queryResult = SqlGenerator.GetSelectBetween(from, to, btwField, predicate);
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
