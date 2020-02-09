using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace WebApplication13.Models
{
    public class Customer
    {
        [Key]
        public int Customer_id { get; set; }
        [Required]
        public int Store_id { get; set; }
        [Required]
        public string First_name { get; set; }
        [Required]
        public string Last_name { get; set; }


        public string Email { get; set; }
        [Required]
        public int Address_id { get; set; }
        [Required]
        public char Active { get; set; }
        [Required]
        public DateTime Create_date { get; set; }
        [Required]
        public DateTime Last_update { get; set; }

        public string Crcard { get; set; }

    }
}
