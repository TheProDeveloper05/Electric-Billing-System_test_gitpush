using EBS.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.ServiceLayer
{
    public interface InterfaceCustomerService
    {
        void CustomerRegistration(Customer CustomerRegistration);
        void EditProfile(Customer EditProfile);

        IList<Customer> CustomersList();

        void DeleteCustomer(int customer_id);
    }
}
