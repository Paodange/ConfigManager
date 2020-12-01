using AutoMapper;
using Mgi.Apl.Model.BO;
using Mgi.Apl.Model.DTO;
using Mgi.Apl.Model.Entity;
using Mgi.Apl.Repository;
using Mgi.Framework.Core.ApiContract;

namespace Mgi.Apl.Service.Impl
{
    public class UserService : AbstractService<User, UserBO, UserDTO, int?>, IUserService
    {
        public UserService(IMapper mapper, IUserRepository repository, IAttachmentRepository attachmentRepository) : base(mapper, repository, attachmentRepository)
        {
        }

        public ApiResponse<LoginResponse> Login(LoginBO bo)
        {
            //return new ApiResponse<LoginResponse>(ResponseCode.InternalServerError, null);
            return new ApiResponse<LoginResponse>(ResponseCode.Ok, new LoginResponse()
            {
                Token = "AAAABBBBCCCC"
            });
        }
    }
}
