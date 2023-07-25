using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.DomainLayer.Models
{
    public class Admin
    {
        [Key]
        [Required]
        
        public int admin_id { get; set; }
        [Required]
        public string admin_name { get; set; }
       
        public string admin_Username { get; set; }

        public string admin_Password { get; set; }

    }
}
