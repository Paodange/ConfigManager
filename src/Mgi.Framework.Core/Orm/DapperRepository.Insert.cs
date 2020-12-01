using System;
using System.Data;
using System.Linq;
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
        public virtual bool Insert(TEntity instance)
        {
            return Insert(instance, null);
        }

        /// <inheritdoc />
        public virtual bool Insert(TEntity instance, IDbTransaction transaction)
        {
            var conn = transaction == null ? ConnectionManager.OpenMaster() : transaction.Connection;
            try
            {
                var queryResult = SqlGenerator.GetInsert(instance);
                if (SqlGenerator.IsIdentity)
                {
                    var newId = conn.Query<PK>(queryResult.GetSql(), queryResult.Param, transaction).FirstOrDefault();
                    return SetValue(newId, instance);
                }
                return conn.Execute(queryResult.GetSql(), instance, transaction) > 0;
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
        public virtual Task<bool> InsertAsync(TEntity instance)
        {
            return InsertAsync(instance, null);
        }

        /// <inheritdoc />
        public virtual async Task<bool> InsertAsync(TEntity instance, IDbTransaction transaction)
        {
            var conn = transaction == null ? ConnectionManager.OpenMaster() : transaction.Connection;
            try
            {
                var queryResult = SqlGenerator.GetInsert(instance);
                if (SqlGenerator.IsIdentity)
                {
                    var newId = (await conn.QueryAsync<PK>(queryResult.GetSql(), queryResult.Param, transaction)).FirstOrDefault();
                    return SetValue(newId, instance);
                }
                return await conn.ExecuteAsync(queryResult.GetSql(), instance, transaction) > 0;
            }
            finally
            {
                if (transaction == null)
                {
                    conn.Close();
                }
            }
        }

        public virtual PK InsertGetId(TEntity instance)
        {
            return InsertGetId(instance, null);
        }
        public virtual PK InsertGetId(TEntity instance, IDbTransaction transaction)
        {
            var conn = transaction == null ? ConnectionManager.OpenMaster() : transaction.Connection;
            try
            {
                var queryResult = SqlGenerator.GetInsert(instance);
                return conn.Query<PK>(queryResult.GetSql(), queryResult.Param, transaction).FirstOrDefault();
            }
            finally
            {
                if (transaction == null)
                {
                    conn.Close();
                }
            }
        }

        public virtual Task<PK> InsertGetIdAsync(TEntity instance)
        {
            return InsertGetIdAsync(instance, null);
        }
        public virtual async Task<PK> InsertGetIdAsync(TEntity instance, IDbTransaction transaction)
        {
            var conn = transaction == null ? ConnectionManager.OpenMaster() : transaction.Connection;
            try
            {
                var queryResult = SqlGenerator.GetInsert(instance);
                return (await conn.QueryAsync<PK>(queryResult.GetSql(), queryResult.Param, transaction)).FirstOrDefault();
            }
            finally
            {
                if (transaction == null)
                {
                    conn.Close();
                }
            }
        }

        private bool SetValue(PK newId, TEntity instance)
        {
            //var newParsedId = Convert.ChangeType(newId, SqlGenerator.IdentitySqlProperty.PropertyInfo.PropertyType);
            SqlGenerator.IdentitySqlProperty.PropertyInfo.SetValue(instance, newId);
            return true;
        }
    }
}