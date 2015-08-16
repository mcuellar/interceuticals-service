using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterceuticalsService.Models
{
    public class ShoppingCartDetails
    {
        public int CartId { get; set; }
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public int ItemCount { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        //[DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }
        //public decimal TotalPrice { get; set; }
    }
}