using Demo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.WebUI.Models
{
    public class HomeListProductViewModel
    {
        public List<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public List<Category> Categories { get; set; }
        public int CurrentCategory { get; set; }
    }
}