using Demo.Domain.Abstract;
using Demo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Concrete
{
    public class MainRepository : IMainRepository
    {
        private readonly DemoEntities _context;
        public MainRepository()
        {
            _context = new DemoEntities();
        }

        public IQueryable<Product> Products
        {
            get
            {
                return _context.Products;
            }
        }

        public IQueryable<Category> Categories => _context.Categories;

        public IQueryable<Customer> Customers => _context.Customers;

        public IQueryable<Province> Provinces => _context.Provinces;
        public IQueryable<Payment> Payments => _context.Payments;
    }
}
