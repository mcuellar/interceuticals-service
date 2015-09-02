using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterceuticalsService.Models
{
    public class Order
    {
        [Required]
        public int CartId { get; set; }

        public int SiteId { get; set; }
        public int PromotionId { get; set; }
        public double ShippingCost { get; set; }
        public double OrderCost { get; set; }
        public double SalesTax { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string ShippingFirstName { get; set; }
        public string ShippingLastName { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingZip { get; set; }
        public string ShippingCountry { get; set; }
        public int ShippingCountryId { get; set; }
        public string ShippingPhone { get; set; }
        public string ShippingMethod { get; set; }
        public string ShippingEmail { get; set; }
        public string Comments { get; set; }
    }
}