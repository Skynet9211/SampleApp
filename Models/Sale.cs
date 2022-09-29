using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SampleApp.Models
{
    public class Sale
    {
        [Key]
        [Display(Name ="ID")]
        public int saleId { get; set; }
        [Display(Name = "Sale Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM.dd.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime saleDate { get; set; }
        [Display(Name = " Product ID")]
        public int productId { get; set; }
        [Display(Name = "Product Name")]
        public string product { get; set; }
        [Display(Name = "Cusomter ID")]
        public int customerId { get; set; }
        [Display(Name = "Customer Name")]
        public string customerName { get; set; }
        [Display(Name = "Price")]
        public int price { get; set; }
        [Display(Name = "Quantity")]
        public int quantity { get; set; }
        [Display(Name = "Total Amount")]
        public int total { get; set; }
        //public virtual IEnumerable<Product> Products { get; set; }
        //public virtual IEnumerable<Customer> Customers { get; set; }





    }
}
