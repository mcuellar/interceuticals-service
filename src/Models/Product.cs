using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterceuticalsService.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public int ParentProductId { get; set; }
        public int SubordinateProductId { get; set; }
        public bool HasAutohip { get; set; }
        public float Price { get; set; }
    }
}