using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterceuticalsService.Models
{
    public class ShoppingCartTotals
    {
        private string totalPrice = "0.00";

        [DefaultValue(0)]
        public int TotalItems { get; set; }

        //[DisplayFormat(DataFormatString = "{0: ####0.00}")]
        //[DefaultValue(0.00)]
        //public double TotalPrice
        //{
        //    get { return totalPrice; }
        //    set { totalPrice = Math.Round(value,2); } 
        //}
        
        //[DefaultValue("0.00")]
        public string TotalPrice 
        { 
            get { return totalPrice; }
            set { totalPrice = value; }
        }
    }
}