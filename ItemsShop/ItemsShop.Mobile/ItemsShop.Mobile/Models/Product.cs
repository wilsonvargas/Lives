using System;
using System.Collections.Generic;
using System.Text;

namespace ItemsShop.Mobile.Models
{
    public class Product
    {
        public string Description { get; set; }
        public int Id { get; set; }
        public Uri Image { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
