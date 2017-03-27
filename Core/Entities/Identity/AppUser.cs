namespace Core.Entities
{
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>
    /// 用户
    /// </summary>
    public class AppUser : IdentityUser
    {
        public const string DEFAULTPASSWORD = "s666666";

        public AppUser()
        {
        }

        public string Name { get; set; }

        public string RoleId => Roles.First().RoleId;

        ////public UserTypeEnum? UserType { get; set; } = UserTypeEnum.晟融;
    }
}
