using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterceuticalsService.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        public string Label { get; set; }
        public int ParentProductId { get; set; }
        public int SubordinateProductId { get; set; }
        public bool HasAutohip { get; set; }
        public double Price { get; set; }
    }
}