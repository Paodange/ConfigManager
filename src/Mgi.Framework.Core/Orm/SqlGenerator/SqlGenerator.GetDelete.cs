using System;
using System.Linq;
using System.Linq.Expressions;

namespace MicroOrm.Dapper.Repositories.SqlGenerator
{
    /// <inheritdoc />
    public partial class SqlGenerator<TEntity>
        where TEntity : class
    {
        /// <inheritdoc />
        public virtual SqlQuery GetDelete(TEntity entity)
        {
            var sqlQuery = new SqlQuery();
            var whereAndSql =
                string.Join(" AND ", KeySqlProperties.Select(p => string.Format("{0}.{1} = @{2}", TableName, p.ColumnName, p.PropertyName)));

            if (!LogicalDelete)
            {
                sqlQuery.SqlBuilder
                    .Append("DELETE FROM ")
                    .Append(TableName)
                    .Append(" WHERE ")
                    .Append(whereAndSql);
            }
            else
            {
                sqlQuery.SqlBuilder
                    .Append("UPDATE ")
                    .Append(TableName)
                    .Append(" SET ")
                    .Append(StatusPropertyName)
                    .Append(" = ")
                    .Append(LogicalDeleteValue);

                if (HasUpdatedAt)
                {
                    UpdatedAtProperty.SetValue(entity, DateTime.UtcNow);

                    sqlQuery.SqlBuilder
                        .Append(", ")
                        .Append(UpdatedAtPropertyMetadata.ColumnName)
                        .Append(" = @")
                        .Append(UpdatedAtPropertyMetadata.PropertyName);
                }

                sqlQuery.SqlBuilder
                    .Append(" WHERE ")
                    .Append(whereAndSql);
            }

            sqlQuery.SetParam(entity);
            return sqlQuery;
        }

        /// <inheritdoc />
        public virtual SqlQuery GetDelete(Expression<Func<TEntity, bool>> predicate)
        {
            var sqlQuery = new SqlQuery();

            if (!LogicalDelete)
            {
                sqlQuery.SqlBuilder
                    .Append("DELETE FROM ")
                    .Append(TableName);
            }
            else
            {
                sqlQuery.SqlBuilder
                    .Append("UPDATE ")
                    .Append(TableName)
                    .Append(" SET ")
                    .Append(StatusPropertyName)
                    .Append(" = ")
                    .Append(LogicalDeleteValue);

                if (HasUpdatedAt)
                    sqlQuery.SqlBuilder
                        .Append(", ")
                        .Append(UpdatedAtPropertyMetadata.ColumnName)
                        .Append(" = @")
                        .Append(UpdatedAtPropertyMetadata.PropertyName);


            }
            sqlQuery.SqlBuilder.Append(" ");
            AppendWherePredicateQuery(sqlQuery, predicate, QueryType.Delete);
            return sqlQuery;
        }

        public virtual SqlQuery GetDeleteById(object id)
        {
            if (KeySqlProperties.Length != 1)
                throw new NotSupportedException("GetDeleteById support only 1 key");
            var sqlQuery = new SqlQuery();
            var keyProperty = KeySqlProperties[0];
            var whereAndSql = string.Format("{0}.{1} = @{2}", TableName, keyProperty.ColumnName, keyProperty.PropertyName);
            if (!LogicalDelete)
            {
                sqlQuery.SqlBuilder
                    .Append("DELETE FROM ")
                    .Append(TableName)
                    .Append(" WHERE ")
                    .Append(whereAndSql);
            }
            else
            {
                sqlQuery.SqlBuilder
                    .Append("UPDATE ")
                    .Append(TableName)
                    .Append(" SET ")
                    .Append(StatusPropertyName)
                    .Append(" = ")
                    .Append(LogicalDeleteValue);
                if (HasUpdatedAt)
                {
                    sqlQuery.SqlBuilder
                        .Append(", ")
                        .Append(UpdatedAtPropertyMetadata.ColumnName)
                        .Append(" = @")
                        .Append(UpdatedAtPropertyMetadata.PropertyName);
                }

                sqlQuery.SqlBuilder
                    .Append(" WHERE ")
                    .Append(whereAndSql);
            }
            sqlQuery.SetParam(new { id });
            return sqlQuery;
        }
    }
}
