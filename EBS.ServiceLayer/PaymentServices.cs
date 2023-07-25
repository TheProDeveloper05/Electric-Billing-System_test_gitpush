using EBS.DomainLayer.Models;
using EBS.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.ServiceLayer
{
    public class PaymentServices : InterfacePaymentService
    {
        public EBSDBContext EBSDBContext;



        public PaymentServices(EBSDBContext ebsdbcontext)
        {
            this.EBSDBContext = ebsdbcontext;
        }




        public void DeletePayment(int payment_no)
        {
            Payment DeletePayment = Payment(payment_no);
            if (DeletePayment != null)
            {
                EBSDBContext.Remove<Payment>(DeletePayment);
                EBSDBContext.SaveChanges();
            }

        }
        private Payment Payment(int payment_no)
        {
            return EBSDBContext.Find<Payment>(payment_no);
        }




        public void UpdatePayment(Payment UpdatePayment)
        {
            try
            {
                EBSDBContext.Update<Payment>(UpdatePayment);
                EBSDBContext.SaveChanges();
            }
            catch (Exception ex)
            {



                throw new Exception(ex.Message); ;
            }
        }



        public void InsertPayment(Payment InsertPayment)
        {
            try
            {
                EBSDBContext.Add<Payment>(InsertPayment);
                EBSDBContext.SaveChanges();
            }
            catch (Exception ex)
            {



                throw new Exception(ex.Message);
            }
        }



        



        public IList<Payment> PaymentsList()
        {
            return EBSDBContext.Set<Payment>().ToList();
        }




    }
}
