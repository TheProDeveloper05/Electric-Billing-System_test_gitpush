using System;
using System.ComponentModel.DataAnnotations;

namespace EBS.DomainLayer.Models
{
    public class Payment
    {
        [Key]
        [Required]
       
        public int payment_no { get; set; }
        
        public string payment_mode { get; set; }
        
        public float payment_amount { get; set; }
        public DateTime payment_date { get; set; }

        public int payment_billno { get; set; }
        
        public DateTime payment_issuedate { get; set; }
        public float bill_previous_reading { get; set; }

        public float bill_energy_charge { get; set; }

        public float consumption_unit { get; set; }
        public float payment_tax { get; set; }
        public float payment_billamount { get; set; }
        public string payment_status { get; set; }
        public int payment_customerid { get; set; }


    }
}
