using Demo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Entities
{
    public class Cart
    {
        public List<CartLine> Lines { get; private set; }
        //constructor
        public Cart()
        {
            Lines = new List<CartLine>();
        }
        //add : check 
        public void Add(Product product, int quantity)
        {
            var line = Lines.FirstOrDefault(x => x.Product.ProductId == product.ProductId);
            if(line == null)
            {
                line = new CartLine()
                {   
                    Product = product,
                    Quantity = quantity
                };
                Lines.Add(line);
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        //update
        public void Update(Product product, int quantity)
        {
            var line = Lines.FirstOrDefault(x => x.Product.ProductId == product.ProductId);
            if(line != null)
            {
                line.Quantity = quantity;
            }    
            
        }


        //remove
        public void Remove(Product product)
        {
            var line = Lines.FirstOrDefault(x => x.Product.ProductId == product.ProductId);
            if(line!=null)
            {
                Lines.Remove(line);
            }    
        }
        //compute total
        public decimal CaculateTotal()
        {
            return Lines.Sum(x => x.Product.Price * x.Quantity);
        }
        //clear
        public void Clear()
        {
            Lines.Clear();
        }
    }
}

