using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineshop.Models
{
    public class allinone
    {
        public  Cart cart { get; set; }
        public Customer customer { get; set; }
        public Order order { get; set; }
        public Orderitems orderitems { get; set; }
        public IList<Products> products { get; set; }
        public SizeColor sizecolor { get; set; }
    }
}
