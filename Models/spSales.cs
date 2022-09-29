using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleApp.Models
{
    [Keyless]
    public class spSales
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM.dd.yyyy}", ApplyFormatInEditMode = true)]
        [NotMapped]
        public DateTime? startDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM.dd.yyyy}", ApplyFormatInEditMode = true)]
        [NotMapped]
        public DateTime? endDate { get; set; }  

    }
}
