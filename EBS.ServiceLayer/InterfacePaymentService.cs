using EBS.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.ServiceLayer
{
public interface InterfacePaymentService 
    { 
        void UpdatePayment(Payment UpdatePayment);
        IList<Payment> PaymentsList();
        //Payment PaymentShowById(int payment_no); 
        void InsertPayment(Payment InsertPayment); 
        void DeletePayment(int payment_no);
        
    }


    
}
