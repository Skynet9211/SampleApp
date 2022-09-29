using System.ComponentModel.DataAnnotations;


namespace SampleApp.Models
{
    public class Customer
    {
        [Key]
        [Display(Name ="ID")]

        public int customerId { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,12}$",
          ErrorMessage = "Numbers are not allowed.")]
        [Display(Name = "Name")]
        public string? customerFirstName { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,12}$",
          ErrorMessage = "Numbers are not allowed.")]
        [Display(Name = "Surname")]
        public string? customerLastName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string? email { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,2}$",
          ErrorMessage = "Numbers are not allowed.")]
        [StringLength(2, ErrorMessage = "Region Cannot exceed 2 Characters")]
        [Display(Name = "Region")]
        public string? region { get; set; }
        [RegularExpression(@"^[A,I]$",
          ErrorMessage = "Only I and A are allowed.")]
        [StringLength(1, ErrorMessage = "Status Cannot exceed 1 Characters")]
        [Display(Name = "Status")]
        public string? status { get; set; }
    }
}
