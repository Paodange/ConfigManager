using Mgi.Apl.Model.Entity;
using MicroOrm.Dapper.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mgi.Apl.Repository
{
    public interface IMaterialRepository : IDapperRepository<Material, int?>
    {
    }
}
