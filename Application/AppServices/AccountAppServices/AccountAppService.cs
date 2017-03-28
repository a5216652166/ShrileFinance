namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AutoMapper;
    using Core.Entities;
    using Core.Entities.Identity;
    using Core.Exceptions;
    using Microsoft.AspNet.Identity;
    using ViewModels.AccountViewModels;
    using X.PagedList;

    public class AccountAppService
    {
        private readonly AppUserManager userManager;
        private readonly AppRoleManager roleManager;

        public AccountAppService(AppUserManager userManager, AppRoleManager roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public System.Security.Principal.IPrincipal User { get; set; }

        /// <summary>
        /// 获取当前用户 [已弃用]
        /// </summary>
        /// <returns></returns>
        public UserViewModel CurrentUser()
        {
            return GetUser(User.Identity.GetUserId());
        }

        /// <summary>
        /// 获取当前角色的标识 [已弃用]
        /// </summary>
        /// <returns></returns>
        public AppRole CurrentRole()
        {
            return roleManager.FindByName(CurrentUser().Role);
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <returns></returns>
        public UserViewModel GetUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullAppException(nameof(userId));
            }

            var user = userManager.FindById(userId);

            var viewModel = Mapper.Map<UserViewModel>(user);

            viewModel.Role = roleManager.FindById(user.RoleId).Name;

            return viewModel;
        }

        /// <summary>
        /// 根据角色获取用户
        /// </summary>
        /// <param name="roleId">角色标识</param>
        /// <returns></returns>
        public IEnumerable<AppUser> GetByRole(string roleId)
        {
            if (string.IsNullOrEmpty(roleId))
            {
                throw new ArgumentNullAppException(nameof(roleId));
            }

            return userManager.Users.Where(m => m.Roles.Any(n => n.RoleId == roleId));
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="searchString">用户名或姓名</param>
        /// <param name="pageNumber">分页页码</param>
        /// <param name="pageSize">分页尺寸</param>
        /// <returns></returns>
        public IPagedList<UserViewModel> List(string searchString, int pageNumber, int pageSize)
        {
            var users = userManager.Users;

            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(m => m.Name.Contains(searchString)
                    || m.UserName.Contains(searchString));
            }

            users = users.OrderByDescending(m => m.Id);

            var userList = Mapper.Map<IPagedList<UserViewModel>>(users.ToPagedList(pageNumber, pageSize));
            
            foreach (var item in userList)
            {
                // 角色补充
                var user = userManager.FindById(item.Id);
                item.Role = roleManager.FindById(user.RoleId).Name;
            }

            return userList;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="model">用户</param>
        /// <returns></returns>
        public async Task<IdentityResult> CreateUserAsync(UserViewModel model)
        {
            var user = Mapper.Map<AppUser>(model);
            user.UserName = model.Username;

            var createResult = await userManager.CreateAsync(user, AppUser.DEFAULTPASSWORD);

            if (!createResult.Succeeded)
            {
                return createResult;
            }

            model.Id = user.Id;

            return await userManager.AddToRoleAsync(user.Id, model.Role);
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="model">用户</param>
        /// <returns></returns>
        public async Task<IdentityResult> ModifyUserAsync(UserViewModel model)
        {
            var user = userManager.FindById(model.Id);
            Mapper.Map(model, user);

            var modify = await userManager.UpdateAsync(user);

            if (!modify.Succeeded)
            {
                return modify;
            }

            var roles = await userManager.GetRolesAsync(user.Id);
            await userManager.RemoveFromRolesAsync(user.Id, roles.ToArray());
            var addRole = await userManager.AddToRoleAsync(user.Id, model.Role);

            return addRole;
        }

        public Task<IdentityResult> ModifyMyInfoAsync(UserInfoViewModel model)
        {
            var user = userManager.FindById(model.Id);
            Mapper.Map(model, user);

            return userManager.UpdateAsync(user);
        }

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public bool CheckUsername(string username)
            => userManager.CheckUsername(username);

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <returns></returns>
        public Task<IdentityResult> ResetPasswordAsync(string userId)
        {
            var token = userManager.GeneratePasswordResetToken(userId);

            return userManager.ResetPasswordAsync(userId, token, AppUser.DEFAULTPASSWORD);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model">修改密码模型</param>
        /// <returns></returns>
        public Task<IdentityResult> ChangePasswordAsync(ChangePasswordViewModel model)
            => userManager.ChangePasswordAsync(model.Id, model.CurrentPassword, model.NewPassword);

        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <returns></returns>
        public Task<IdentityResult> EnableAsync(string userId)
            => userManager.SetLockoutEnabledAsync(userId, false);

        /// <summary>
        /// 停用
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <returns></returns>
        public Task<IdentityResult> DisableAsync(string userId)
            => userManager.SetLockoutEnabledAsync(userId, true);

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model">登录模型</param>
        /// <returns></returns>
        public async Task<ClaimsIdentity> Login(LoginViewModel model)
        {
            var user = await userManager.FindAsync(model.Username, model.Password);

            if (user == null)
            {
                throw new ArgumentNullAppException(message: "用户名或密码无效.");
            }
            else if (user.LockoutEnabled)
            {
                throw new ArgumentNullAppException(message: "账户已停用.");
            }

            return await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
        }

        /// <summary>
        /// 获取角色
        /// </summary>
        /// <param name="roleId">角色标识</param>
        /// <returns></returns>
        public AppRole GetRole(string roleId)
        {
            if (string.IsNullOrEmpty(roleId))
            {
                throw new ArgumentNullAppException(nameof(roleId));
            }

            return roleManager.FindById(roleId);
        }

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AppRole> GetRoles()
            => roleManager.Roles;

        /// <summary>
        /// 将用户添加到角色
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <param name="role">角色</param>
        /// <returns></returns>
        public Task<IdentityResult> AddToRoleAsync(string userId, AppRole role)
            => userManager.AddToRoleAsync(userId, role.Id);
    }
}
