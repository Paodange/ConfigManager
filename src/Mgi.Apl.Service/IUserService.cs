using Mgi.Apl.Model.BO;
using Mgi.Apl.Model.DTO;
using Mgi.Apl.Model.Entity;
using Mgi.Framework.Core.ApiContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mgi.Apl.Service
{
    public interface IUserService : IBaseService<User, UserBO, UserDTO, int?>
    {
        ApiResponse<LoginResponse> Login(LoginBO bo);
    }
}
