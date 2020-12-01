using Mgi.Apl.Model.BO;
using Mgi.Apl.Model.DTO;
using Mgi.Apl.Model.Entity;
using Mgi.Apl.Service;
using Mgi.Framework.Core;
using Mgi.Framework.Core.ApiContract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Mgi.Apl.Web.Controllers
{
    /// <summary>
    /// 用户相关操作接口
    /// </summary>
    [Route("api/user")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public IUserService Service { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public UserController(IUserService service)
        {
            Service = service;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="bo"></param>
        /// <returns></returns>
        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public ApiResponse<LoginResponse> Login(LoginBO bo)
        {
            return Service.Login(bo);
        }
        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        [Route("logout")]
        [HttpPost]
        public ApiResponse Logout()
        {
            return ResponseCode.Ok;
        }
        /// <summary>
        /// 根据id查看明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpGet]
        public ApiResponse<UserDTO> Detail(int id)
        {
            return new ApiResponse<UserDTO>(ResponseCode.Ok, Service.GetById(id));
        }

        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResponse<int?> Create(UserBO model)
        {
            return new ApiResponse<int?>(ResponseCode.Ok, Service.Add(model));
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public ApiResponse<int> Update(UserBO model)
        {
            return new ApiResponse<int>(ResponseCode.Ok, Service.Update(model));
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpDelete]
        public ApiResponse<int> Delete(int id)
        {
            return new ApiResponse<int>(ResponseCode.Ok, Service.Delete(id));
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="searchArgs"></param>
        /// <returns></returns>
        [Route("search")]
        [HttpPost]
        public ApiResponse<PageResult<UserDTO>> Search(SearchArgs<User> searchArgs)
        {
            return new ApiResponse<PageResult<UserDTO>>(ResponseCode.Ok, Service.Search(searchArgs));
        }
    }
}
