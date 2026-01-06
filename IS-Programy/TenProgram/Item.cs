using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenProgram
{
    public class Item
    {
        public string Name { get; set; }
        public decimal PriceForOne { get; set; }
        public int Quantity { get; set; }
        public bool IsHQ { get; set; }
    }
}