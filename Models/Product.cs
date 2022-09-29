using System.ComponentModel.DataAnnotations;

namespace SampleApp.Models
{
    public class Product
    {
        [Key]
        [Display(Name ="ID")]
        public int productId { get; set; }
        [Required]
        [Display(Name = "Product")]
        public string name { get; set; }
        [Display(Name = "Price(USD)")]
        [RegularExpression(@"^[0-9 '\s]{1,12}$",
          ErrorMessage = "Only numbers  are allowed.")]
        public int price { get; set; }
    }
}
