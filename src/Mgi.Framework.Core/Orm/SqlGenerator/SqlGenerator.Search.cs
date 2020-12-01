
using Dapper;
using Mgi.Framework.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Mgi.Framework.Core.Orm.Extensions;

namespace MicroOrm.Dapper.Repositories.SqlGenerator
{
    public partial class SqlGenerator<TEntity>
        where TEntity : class
    {
        public virtual Tuple<SqlQuery, SqlQuery> GetSearch(SearchArgs<TEntity> searchArgs)
        {
            var sqlQuery = InitBuilderSelect(false);
            //var joinsBuilder = AppendJoinToSelect(sqlQuery);
            sqlQuery.SqlBuilder
                .Append(" FROM ")
                .Append(TableName)
                .Append(" ");

            //if (includes.Any())
            //    sqlQuery.SqlBuilder.Append(joinsBuilder);
            var parameters = new DynamicParameters();
            parameters.Add(nameof(searchArgs.Keyword), searchArgs.Keyword);
            parameters.Add(nameof(searchArgs.PageIndex), searchArgs.PageIndex);
            parameters.Add(nameof(searchArgs.PageSize), searchArgs.PageSize);
            var fuzzyConditions = new List<string>(50);
            var conditions = new List<string>(50);
            var dbConcatChar = GetDbConcatChar();
            if (searchArgs.Model != null || !string.IsNullOrWhiteSpace(searchArgs.Keyword))
            {
                foreach (var propertyMetadata in SqlProperties)
                {
                    //模糊搜索
                    if (!string.IsNullOrWhiteSpace(searchArgs.Keyword) && propertyMetadata.PropertyInfo.PropertyType == typeof(string))
                    {
                        fuzzyConditions.Add($"{propertyMetadata.ColumnName} LIKE '%'{dbConcatChar}@{nameof(searchArgs.Keyword)}{dbConcatChar}'%'");
                    }
                    if (searchArgs.Model != null)
                    {
                        var value = propertyMetadata.PropertyInfo.GetValue(searchArgs.Model);
                        if (!value.IsNullOrEmptyString())
                        {
                            conditions.Add($"{propertyMetadata.ColumnName} = @{propertyMetadata.PropertyName}");
                            parameters.Add(propertyMetadata.PropertyName, value);
                        }
                    }
                }
            }
            var appendWhere = false;
            if (conditions.Count > 0)
            {
                sqlQuery.SqlBuilder.Append("WHERE ").Append(string.Join(" AND ", conditions));
                appendWhere = true;
            }
            if (fuzzyConditions.Count > 0)
            {
                sqlQuery.SqlBuilder.Append(appendWhere ? " AND " : " WHERE ");
                sqlQuery.SqlBuilder.Append("(").Append(string.Join(" OR ", fuzzyConditions)).Append(")");
                appendWhere = true;
            }
            if (searchArgs.CustomConditions != null && searchArgs.CustomConditions.Count > 0)
            {
                sqlQuery.SqlBuilder.Append(appendWhere ? " AND " : " WHERE ");
                for (int i = 0; i < searchArgs.CustomConditions.Count; i++)
                {
                    var condition = searchArgs.CustomConditions[i];
                    sqlQuery.SqlBuilder.Append(GetCustomConditionSql(condition, parameters));
                    if (i != searchArgs.CustomConditions.Count - 1)
                    {
                        sqlQuery.SqlBuilder.Append(" AND ");
                    }
                }
            }
            if (searchArgs.OrderConditions != null && searchArgs.OrderConditions.Count > 0)
            {
                sqlQuery.SqlBuilder.Append(GetOrderByClause(searchArgs.OrderConditions));
            }
            else  //没有自定义排序默认按主键排序 升序
            {
                var pkColumn = KeySqlProperties.FirstOrDefault();
                if (pkColumn != null)
                {
                    sqlQuery.SqlBuilder.Append($" ORDER BY {pkColumn.ColumnName} ");
                }
            }
            var sql = sqlQuery.SqlBuilder.ToString();
            var countSql = $"SELECT COUNT(1) FROM ({sql}) T";
            if (searchArgs.Pagination && (Config.SqlProvider == SqlProvider.MySQL || Config.SqlProvider == SqlProvider.PostgreSQL))
            {
                sql += $" LIMIT  {searchArgs.PageSize} OFFSET { (searchArgs.PageIndex - 1) * searchArgs.PageSize}";
            }
            else if (Config.SqlProvider == SqlProvider.MSSQL)
            {
                var minRow = (searchArgs.PageIndex - 1) * searchArgs.PageSize;
                var maxRow = searchArgs.PageIndex * searchArgs.PageSize;
                sql = $@"SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY Id) AS __ROWINDEX,T.* FROM ({sql}) T ) D 
                                WHERE __ROWINDEX>{minRow} AND __ROWINDEX<={maxRow}";
            }
            var dataQuery = SqlQuery.FromSql(sql, parameters);
            var countQuery = SqlQuery.FromSql(countSql, parameters);
            return new Tuple<SqlQuery, SqlQuery>(dataQuery, countQuery);
        }
        private string GetDbConcatChar()
        {
            switch (Config.SqlProvider)
            {
                case SqlProvider.MSSQL:
                    return "+";
                case SqlProvider.MySQL:
                    return "+";
                case SqlProvider.PostgreSQL:
                    return "||";
                default:
                    throw new Exception("un support database type");
            }
        }
        private string GetCustomConditionSql(SearchCondition condition, DynamicParameters parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($" {string.Empty.PadLeft(condition.LeftBracket, '(')} ").Append($" \"{condition.Field}\" ");
            switch (condition.CompareType)
            {
                case CompareType.EQ:
                    sb.Append($" = @__VALUE__ ");
                    parameters.Add("__VALUE__", condition.Values[0]);
                    break;
                case CompareType.GT:
                    sb.Append(" > @__VALUE__ ");
                    parameters.Add("__VALUE__", condition.Values[0]);
                    break;
                case CompareType.GTE:
                    sb.Append(" >= @__VALUE__ ");
                    parameters.Add("__VALUE__", condition.Values[0]);
                    break;
                case CompareType.LT:
                    sb.Append(" < @__VALUE__ ");
                    parameters.Add("__VALUE__", condition.Values[0]);
                    break;
                case CompareType.LTE:
                    sb.Append(" <= @__VALUE__ ");
                    parameters.Add("__VALUE__", condition.Values[0]);
                    break;
                case CompareType.LIKE:
                    sb.Append(" LIKE @__VALUE__ ");
                    parameters.Add("__VALUE__", condition.Values[0]);
                    break;
                case CompareType.NOT_LIKE:
                    sb.Append(" NOT LIKE @__VALUE__ ");
                    parameters.Add("__VALUE__", condition.Values[0]);
                    break;
                case CompareType.BETWEEN:
                    sb.Append(" BETWEEN @__VALUE1__ AND @__VALUE2__ ");
                    parameters.Add("__VALUE1__", condition.Values[0]);
                    parameters.Add("__VALUE2__", condition.Values[1]);
                    break;
                case CompareType.IN:
                    sb.Append($" IN @__VALUES__");
                    parameters.Add("__VALUES__", condition.Values);
                    break;
                case CompareType.NO_IN:
                    sb.Append($" NOT IN @__VALUES__");
                    parameters.Add("__VALUES__", condition.Values);
                    break;
                default:
                    break;
            }
            sb.Append($" {string.Empty.PadRight(condition.RightBracket, ')')} ");
            return sb.ToString();
        }
        private string GetOrderByClause(List<OrderCondition> orderConditions)
        {
            if (orderConditions == null || orderConditions.Count <= 0)
            {
                return string.Empty;
            }
            var sb = new StringBuilder();
            sb.Append(" ORDER BY ");
            foreach (var c in orderConditions)
            {
                sb.Append($" {c.Field} {c.OrderType.ToString()} ");
            }
            return sb.ToString();
        }
    }
}
