using EBS.DomainLayer.Models;
using EBS.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.ServiceLayer
{
    public class BillServices : InterfaceBillService
    {
        public EBSDBContext EBSDBContext;
        public BillServices(EBSDBContext ebsdbcontext)
        {
            this.EBSDBContext = ebsdbcontext;
        }

        public IList<Bill> BillList()
        {
            return EBSDBContext.Set<Bill>().ToList();
        }
        

        public void InsertBill(Bill InsertBill)
        {
            try
            {
                EBSDBContext.Add<Bill>(InsertBill);
                EBSDBContext.SaveChanges();
            }
            catch (Exception ex)
            {



                throw new Exception(ex.Message);
            }
        }
        public void EditBill(Bill EditBill)
        {
            try
            {
                EBSDBContext.Update<Bill>(EditBill);
                EBSDBContext.SaveChanges();
            }
            catch (Exception ex)
            {



                throw new Exception(ex.Message); ;
            }
        }
        public void DeleteBill(int bill_id)
        {
            Bill DeleteBill = Bill(bill_id);
            if (DeleteBill != null)
            {
                EBSDBContext.Remove<Bill>(DeleteBill);
                EBSDBContext.SaveChanges();
            }

        }
        private Bill Bill(int bill_id)
        {
            return EBSDBContext.Find<Bill>(bill_id);
        }

    }
}
