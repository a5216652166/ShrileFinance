namespace Application.ViewModels.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class UserViewModel
    {
        [StringLength(128)]
        public string Id { get; set; }

        [Required]
        [StringLength(256)]
        [Display(Name = "用户名")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Required]
        public string Role { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "邮箱")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "手机")]
        public string Phone { get; set; }

        public bool LockoutEnabled { get; set; }

        public string LockoutEnabledDesc => LockoutEnabled ? "停用" : "启用";
    }
}
