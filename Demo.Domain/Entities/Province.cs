using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Entities
{
    public class Province
    {
        [Key]
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public Province()
        {
            Customers = new HashSet<Customer>();
        }
    }
}
