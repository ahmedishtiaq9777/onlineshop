using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace onlineshop.Models
{
    public partial class Products
    {
        public Products()
        {
           
            Orderitems = new HashSet<Orderitems>();
            SizeColor = new HashSet<SizeColor>();
        }

        public int ProductId { get; set; }
        [Required(ErrorMessage = "This is  required")]
        public string ProductTitle { get; set; }
        [Required(ErrorMessage = "This is  required")]
        public string ProductCode { get; set; }
       [Required(ErrorMessage ="This is required")]
        public string ProductDisc { get; set; }
         [Required(ErrorMessage = "This is  required")]
        public double? ProductPrice { get; set; }
        [Required(ErrorMessage = "This is  required")]
        public string ProductImg1 { get; set; }
       
        public string ProductImg2 { get; set; }
        
        public string ProductImg3 { get; set; }
        
            [DataType(DataType.Currency)]
        public int? ProductQty { get; set; }
        [Required(ErrorMessage = "This is  required")]
        public string Categories { get; set; }
        
        public string Brand { get; set; }
        public string Type { get; set; }

        
        public virtual ICollection<Orderitems> Orderitems { get; set; }
        public virtual ICollection<SizeColor> SizeColor { get; set; }
    }
}
