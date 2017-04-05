namespace Application.Produce.ProduceViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class PrincipalRatioViewModel
    {
        [Required]
        public int Period { get; set; }

        [Required]
        public decimal Ratio { get; set; }

        public decimal Factor { get; set; }
    }
}