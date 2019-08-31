using System;
using System.Collections.Generic;

namespace onlineshop.Models
{
    public partial class Cart
    {
        public Cart()
        {
            Orderitems = new HashSet<Orderitems>();
        }

        public int CartId { get; set; }
        public int? CustomerId { get; set; }
        public string Total { get; set; }
        public int? ProductId { get; set; }
        public int? SizeId { get; set; }

        public virtual ICollection<Orderitems> Orderitems { get; set; }
        public virtual Customer Customer { get; set; }





    }
}
