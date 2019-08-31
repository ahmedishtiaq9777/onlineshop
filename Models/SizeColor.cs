using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace onlineshop.Models
{
    public partial class SizeColor
    {
        public int ScId { get; set; }
        [Required(ErrorMessage ="THis is Required")]
        public string Size { get; set; }
        [Required(ErrorMessage = "THis is Required")]
        public string Color { get; set; }
        [Required(ErrorMessage="This is Required")]
        public int? ProductId { get; set; }

        
    }
}
