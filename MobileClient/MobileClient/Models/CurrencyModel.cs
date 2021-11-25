using System;
using System.Collections.Generic;
using System.Text;

namespace MobileClient.Models
{
    public class CurrencyModel
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public float Owned { get; set; }
        public float PriceChange { get; set; }
    }
}
