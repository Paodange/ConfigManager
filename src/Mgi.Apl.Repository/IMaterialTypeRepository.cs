using Mgi.Apl.Model.Entity;
using MicroOrm.Dapper.Repositories;

namespace Mgi.Apl.Repository
{
    public interface IMaterialTypeRepository : IDapperRepository<MaterialType, int?>
    {
    }
}
