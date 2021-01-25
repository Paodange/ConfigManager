using Mgi.Apl.Model.BO;
using Mgi.Apl.Model.DTO;
using Mgi.Apl.Model.Entity;

namespace Mgi.Apl.Service
{
    public interface IUserService : IBaseService<User, UserBO, UserDTO, int?>
    {
        string Login(LoginBO bo);
    }
}
