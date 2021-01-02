using Demo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Concrete
{
    public class DemoEntities : DbContext
    {
        public DemoEntities()
            : base("DefaultConnection")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
