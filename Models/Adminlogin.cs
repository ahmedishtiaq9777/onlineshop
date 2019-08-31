using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace onlineshop.Models
{
    public partial class Adminlogin
    {
        public int Adminid { get; set; }
        [Required(ErrorMessage ="This is  required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This is  required")]
        public string Password { get; set; }

    }
}
