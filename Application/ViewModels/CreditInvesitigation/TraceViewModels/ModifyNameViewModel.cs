namespace Application.ViewModels.CreditInvesitigation.TraceViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ModifyNameViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "名称")]
        [StringLength(20)]
        public string Name { get; set; }
    }
}
