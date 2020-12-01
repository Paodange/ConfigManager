using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.SqlGenerator;

namespace Mgi.Apl.Repository
{
    /// <summary>
    /// 通用增删改查抽象仓储基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="PK"></typeparam>
    public abstract class AbstractRepository<T, PK> : DapperRepository<T, PK> where T : class
    {
        public AbstractRepository() :
            base(new SqlGeneratorConfig() { SqlProvider = SqlProvider.PostgreSQL, UseQuotationMarks = true })
        {

        }
    }
}
