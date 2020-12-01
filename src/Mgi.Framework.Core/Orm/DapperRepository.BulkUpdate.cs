using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Mgi.Framework.Core;
using MicroOrm.Dapper.Repositories.SqlGenerator;

namespace MicroOrm.Dapper.Repositories
{
    /// <summary>
    ///     Base Repository
    /// </summary>
    public partial class DapperRepository<TEntity, PK>
        where TEntity : class
    {
        /// <inheritdoc />
        public int BulkUpdate(IEnumerable<TEntity> instances)
        {
            return BulkUpdate(instances, null);
        }

        /// <inheritdoc />
        public int BulkUpdate(IEnumerable<TEntity> instances, IDbTransaction transaction)
        {
            var conn = transaction == null ? ConnectionManager.OpenMaster() : transaction.Connection;
            try
            {
                if (SqlGenerator.Config.SqlProvider == SqlProvider.MSSQL)
                {
                    int count = 0;
                    int totalInstances = instances.Count();

                    var properties = SqlGenerator.SqlProperties.ToList();

                    int exceededTimes = (int)Math.Ceiling(totalInstances * properties.Count / 2100d);
                    if (exceededTimes > 1)
                    {
                        int maxAllowedInstancesPerBatch = totalInstances / exceededTimes;

                        for (int i = 0; i <= exceededTimes; i++)
                        {
                            var items = instances.Skip(i * maxAllowedInstancesPerBatch).Take(maxAllowedInstancesPerBatch);
                            var msSqlQueryResult = SqlGenerator.GetBulkUpdate(items);
                            count += conn.Execute(msSqlQueryResult.GetSql(), msSqlQueryResult.Param, transaction);
                        }
                        return count;
                    }
                }
                var queryResult = SqlGenerator.GetBulkUpdate(instances);
                return conn.Execute(queryResult.GetSql(), queryResult.Param, transaction);
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
        public Task<int> BulkUpdateAsync(IEnumerable<TEntity> instances)
        {
            return BulkUpdateAsync(instances, null);
        }

        /// <inheritdoc />
        public async Task<int> BulkUpdateAsync(IEnumerable<TEntity> instances, IDbTransaction transaction)
        {
            var conn = transaction == null ? ConnectionManager.OpenMaster() : transaction.Connection;
            try
            {
                if (SqlGenerator.Config.SqlProvider == SqlProvider.MSSQL)
                {
                    int count = 0;
                    int totalInstances = instances.Count();

                    var properties = SqlGenerator.SqlProperties.ToList();

                    int exceededTimes = (int)Math.Ceiling(totalInstances * properties.Count / 2100d);
                    if (exceededTimes > 1)
                    {
                        int maxAllowedInstancesPerBatch = totalInstances / exceededTimes;

                        for (int i = 0; i <= exceededTimes; i++)
                        {
                            var items = instances.Skip(i * maxAllowedInstancesPerBatch).Take(maxAllowedInstancesPerBatch);
                            var msSqlQueryResult = SqlGenerator.GetBulkUpdate(items);
                            count += await conn.ExecuteAsync(msSqlQueryResult.GetSql(), msSqlQueryResult.Param, transaction);
                        }
                        return count;
                    }
                }
                var queryResult = SqlGenerator.GetBulkUpdate(instances);
                return await conn.ExecuteAsync(queryResult.GetSql(), queryResult.Param, transaction);
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