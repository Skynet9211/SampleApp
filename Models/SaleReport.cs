using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SampleApp.Models
{
        [Keyless]
    public class SaleReport
    {
        [Display(Name ="Product ID")]
        public int? ProductId { get; set; }
        [Display(Name="Product Name")]
        public string Name { get; set; }
        [Display(Name="Quantity")]
        public int? Quantity { get; set; }
        [Display(Name="Total")]
        public int? TotalAmount { get; set; }
    }
}
