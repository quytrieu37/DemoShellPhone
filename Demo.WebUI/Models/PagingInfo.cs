using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.WebUI.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
        public int CurentPage { get; set; }
        public int TotalPages
        {
            get => (int)Math.Ceiling(Convert.ToDecimal(TotalItems) / PageSize);
        }
    }
}