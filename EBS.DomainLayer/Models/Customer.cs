using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.DomainLayer.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int customer_id { get; set; }
        [Required]
        public string customer_name { get; set; }
        
        public string customer_address { get; set; }
        [EmailAddress]
        public string customer_email { get; set; }
        [Phone]
        public string customer_mobile { get; set; }
        
        public string customer_Username { get; set; }

        public string customer_Password { get; set; }
    }
}
