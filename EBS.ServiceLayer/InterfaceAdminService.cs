using EBS.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.ServiceLayer
{
    public interface InterfaceAdminService
    {
        void AdminRegistration(Admin AdminRegistration);

        

        void EditProfile(Admin EditProfile);

       
       
    }

}
