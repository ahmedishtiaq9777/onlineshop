using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace onlineshop.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Cart = new HashSet<Cart>();
            Order = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string CustomerFull { get; set; }
        [Required(ErrorMessage ="This is Required")]
        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }
        [Required(ErrorMessage = "This is Required")]
        [MaxLength(10)]
        public string CustomerPass { get; set; }
        public string CustomerHint { get; set; }
        public string CustomerAdd { get; set; }
        public string CustomerDob { get; set; }
       

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Order> Order{ get; set; }
       
    }
}
