using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterceuticalsService.Models
{
    public class ShoppingCart
    {
        public string Id { get; set; }
        public string SessionId { get; set; }
        public float OrderPrice { get; set; }
        public int TotalItems { get; set; }
        public Product CartProduct { get; set; }
            
    }
}