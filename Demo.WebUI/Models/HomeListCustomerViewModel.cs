using Demo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.WebUI.Models
{
    public class HomeListCustomerViewModel
    {
        public List<Customer> Customers { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public List<Province> Provinces { get; set; }
        public  int CurrentProvince { get;set; }
    }
}