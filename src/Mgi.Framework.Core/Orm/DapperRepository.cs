using System.Data;
using System.Threading.Tasks;
using Mgi.Framework.Core;
using MicroOrm.Dapper.Repositories.SqlGenerator;

namespace MicroOrm.Dapper.Repositories
{
    /// <summary>
    ///     Base Repository
    /// </summary>
    public partial class DapperRepository<TEntity, PK> : IDapperRepository<TEntity, PK>
        where TEntity : class
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        public DapperRepository(SqlProvider sqlProvider)
        {
            SqlGenerator = new SqlGenerator<TEntity>(sqlProvider);
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public DapperRepository(ISqlGenerator<TEntity> sqlGenerator)
        {
            SqlGenerator = sqlGenerator;
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public DapperRepository(SqlGeneratorConfig config)
        {
            SqlGenerator = new SqlGenerator<TEntity>(config);
        }

        /// <inheritdoc />
        public ISqlGenerator<TEntity> SqlGenerator { get; }

    }
}