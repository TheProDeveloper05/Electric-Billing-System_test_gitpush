using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.DomainLayer.Models
{
    public class Bill
    {
        [Key]
        [Required]
        
        public int bill_id { get; set; }
        [Required]
        public float bill_amount { get; set; }
        
        public string bill_paymentMode { get; set; }

        public DateTime bill_issuedate { get; set; }
        public DateTime bill_payingdate { get; set; }

        public string bill_status { get; set; }

        public float bill_present_reading { get; set; }

        public float bill_previous_reading { get; set; }

        public float bill_energy_charge { get; set; }

        public int bill_customerid { get; set; }
    }
}
