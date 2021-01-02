using Demo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Abstract
{
    public interface IMainRepository
    {
        IQueryable<Product> Products { get; }
        IQueryable<Category> Categories { get; }
        IQueryable<Customer> Customers { get; }
        IQueryable<Province> Provinces { get; }
        IQueryable<Payment> Payments { get; }
    }

}
