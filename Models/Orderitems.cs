using System;
using System.Collections.Generic;

namespace onlineshop.Models
{
    public partial class Orderitems
    {

        public int ItemId { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int? Quantity { get; set; }
        public int? ProductId { get; set; }
        public int? OrderId { get; set; }
        public int? CartId { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Order Order { get; set; }
        public Products Product { get; set; }
    }
}
