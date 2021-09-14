using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DevTask.Models
{
    public class Customers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
      
        public string CustomerFirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerLastName { get; set; }
        [Required]
        public string CustomerGender { get; set; }
        [Required]
        [DataType(DataType.Date)]

        public DateTime CustomerDOB { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerEmail { get; set; }
    }
}
