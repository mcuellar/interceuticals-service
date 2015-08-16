using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterceuticalsService.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int CartItemId { get; set; }

        [Required]
        public string SessionId { get; set; }
        public float OrderPrice { get; set; }
        public int TotalItems { get; set; }
        public Product CartProduct { get; set; }
        public List<Product> Products { get; set; }
            
    }
}