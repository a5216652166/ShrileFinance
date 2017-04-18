namespace Web.Controllers.Account
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Application;
    using Application.ViewModels.AccountViewModels;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;
    using Models;

    public class UserController : ApiController
    {
        private readonly AccountAppService service;

        public UserController(AccountAppService userService)
        {
            service = userService;
            service.User = User;
        }

        private IAuthenticationManager AuthManager => Request.GetOwinContext().Authentication;

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="searchString">搜索字符串</param>
        /// <param name="page">页码</param>
        /// <param name="rows">尺寸</param>
        /// <returns></returns>
        public IHttpActionResult GetAll(string searchString, int page, int rows)
        {
            var list = service.List(searchString, page, rows);

            return Ok(new
            {
                rows = list.OrderBy(m => m.Username),
                total = list.TotalItemCount
            });
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="id">用户标识</param>
        /// <returns></returns>
        public IHttpActionResult Get(string id)
        {
            var user = service.GetUser(id);

            return user != null ? (IHttpActionResult)Ok(user) : NotFound();
        }

        /// <summary>
        /// 用户选项
        /// </summary>
        /// <param name="roleId">角色标识</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ComboInfo> Option(string roleId)
            => service.GetByRole(roleId).Select(m => new ComboInfo(m.Id, m.Name));

        /// <summary>
        /// 注册帐号
        /// </summary>
        /// <param name="model">视图模型</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Post(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (service.CheckUsername(model.Username))
            {
                return BadRequest("用户名已存在");
            }

            var result = default(IdentityResult);

            try
            {
                result = await service.CreateUserAsync(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();

            ////try
            ////{
            ////    result = await accountAppService.CreateUserAsync(model);

            ////    if (!result.Succeeded)
            ////    {
            ////        return GetErrorResult(result);
            ////    }

            ////    return Ok();
            ////}
            ////catch (Exception ex)
            ////{
            ////    return BadRequest(ex.Message);
            ////}
        }

        /// <summary>
        /// 修改帐号
        /// </summary>
        /// <param name="model">视图模型</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IHttpActionResult> Put(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await service.ModifyUserAsync(model);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        /// <summary>
        /// 修改我的信息
        /// </summary>
        /// <param name="model">视图模型</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IHttpActionResult> ModifyMyInfo(UserInfoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await service.ModifyMyInfoAsync(model);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model">视图模型</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> SignIn(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                AuthManager.SignOut();

                AuthManager.SignIn(
                    new AuthenticationProperties
                    {
                        IsPersistent = false,

                        // 设置登陆有效时长 6h
                        ExpiresUtc = new DateTimeOffset(DateTime.UtcNow.AddHours(6))
                    },
                    await service.Login(model));

                return Ok();
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult SignOut()
        {
            AuthManager.SignOut();

            return Ok();
        }

        /// <summary>
        /// 查询当前用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult CurrentUser()
        {
            var user = service.CurrentUser();

            return Ok(user);
        }

        /// <summary>
        /// 检查用户名
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult CheckUsername(string username)
        {
            return !service.CheckUsername(username) ? (IHttpActionResult)Ok() : BadRequest();
        }

        /// <summary>
        /// 启用帐号
        /// </summary>
        /// <param name="id">用户标识</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> Enable(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest($"{nameof(id)} 不可为空.");
            }

            var result = await service.EnableAsync(id);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        /// <summary>
        /// 禁用帐号
        /// </summary>
        /// <param name="id">用户标识</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> Disable(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest($"{nameof(id)} 不可为空.");
            }

            var result = await service.DisableAsync(id);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="id">用户标识</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> ResetPassword(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest($"{nameof(id)} 不可为空.");
            }

            var result = await service.ResetPasswordAsync(id);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model">视图模型</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> PasswordEdit(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            model.Id = User.Identity.GetUserId();

            var result = await service.ChangePasswordAsync(model);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        /// <summary>
        /// 编辑权限
        /// </summary>
        /// <param name="model">视图模型</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult PermissionEdit(MenuPermissionsInfo model)
        {
            if (string.IsNullOrEmpty(model.RoleId))
            {
                return BadRequest("角色不能为空.");
            }

            BLL.User.Permissions menuPermissions = new BLL.User.Permissions();

            return menuPermissions.MenuPermissionEdit(model) ? (IHttpActionResult)Ok() : BadRequest("保存失败");
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // 没有可发送的 ModelState 错误，因此仅返回空 BadRequest。
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
