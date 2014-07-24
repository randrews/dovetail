using FubuValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaWeb.Data
{
    public class PhoneNumber
    {
        [Required]
        public int AreaCode { get; set; }
        [Required]
        public int Prefix { get; set; }
        [Required]
        public int Suffix { get; set; }
    }
}
