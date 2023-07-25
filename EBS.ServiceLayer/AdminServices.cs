using EBS.DomainLayer.Models;
using EBS.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.ServiceLayer
{
    public class AdminServices : InterfaceAdminService
    {
        public EBSDBContext EBSDBContext;

        public AdminServices(EBSDBContext ebsdbcontext)
        {
            this.EBSDBContext = ebsdbcontext;
        }
       
        public void AdminRegistration(Admin AdminRegistration)
        {
            EBSDBContext.Add<Admin>(AdminRegistration);
            EBSDBContext.SaveChanges();

        }
       

        void InterfaceAdminService.EditProfile(Admin EditProfile)
        {
            EBSDBContext.Update<Admin>(EditProfile);
            EBSDBContext.SaveChanges();

        }
        
       
    }
}
