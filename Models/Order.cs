using System;
using System.Collections.Generic;

namespace onlineshop.Models
{
    public partial class Order
    {
        public Order()
        {
            
            Orderitems = new HashSet<Orderitems>();
        }

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public string Status { get; set; }
        public DateTime? Date { get; set; }

       
        public virtual ICollection<Orderitems> Orderitems { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
