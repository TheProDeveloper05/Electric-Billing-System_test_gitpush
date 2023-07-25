using EBS.DomainLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBS.DomainLayer.Models;

namespace EBS.RepositoryLayer
{
    public class EBSDBContext : DbContext
    {
        public EBSDBContext(DbContextOptions options) : base(options)
        {


        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Bill> Bill { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Payment> Payment { get; set; }
        
    }
}
