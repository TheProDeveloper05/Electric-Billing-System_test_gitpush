using EBS.DomainLayer.Models;
using EBS.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.ServiceLayer
{
    public class CustomerServices : InterfaceCustomerService
    {
        public EBSDBContext EBSDBContext;

        public CustomerServices(EBSDBContext ebsdbcontext)
        {
            this.EBSDBContext = ebsdbcontext;
        }
        public void CustomerRegistration(Customer CustomerRegistration)
        {
            EBSDBContext.Add<Customer>(CustomerRegistration);
            EBSDBContext.SaveChanges();

        }
        void InterfaceCustomerService.EditProfile(Customer EditProfile)
        {
            EBSDBContext.Update<Customer>(EditProfile);
            EBSDBContext.SaveChanges();

        }
        public IList<Customer> CustomersList()
        {
            return EBSDBContext.Set<Customer>().ToList();
        }

        public void DeleteCustomer(int customer_id)
        {
            Customer DeleteCustomer = Customer(customer_id);
            if (DeleteCustomer != null)
            {
                EBSDBContext.Remove<Customer>(DeleteCustomer);
                EBSDBContext.SaveChanges();
            }


        }
        private Customer Customer(int customer_id)
        {
            return EBSDBContext.Find<Customer>(customer_id);
        }



    }
}
