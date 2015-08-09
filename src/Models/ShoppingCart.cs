using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterceuticalsService.Models
{
    public class ShoppingCart
    {
        public string CartId { get; set; }
        public string SessionId { get; set; }
        public Product product { get; set; }
            
    }
}