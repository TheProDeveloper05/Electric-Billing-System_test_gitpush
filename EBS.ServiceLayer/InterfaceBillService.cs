using EBS.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.ServiceLayer
{
    public interface InterfaceBillService
    {
        void EditBill(Bill EditBill);
        void InsertBill(Bill InsertBill);
        void DeleteBill(int bill_customerid);
        IList<Bill> BillList();
       



    }
}
