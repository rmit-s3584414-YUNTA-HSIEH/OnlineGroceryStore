using System;
using System.Collections.Generic;
using System.Text;

namespace OnlinegGroceryStore
{
    class Product
    {
        public string Name { get;}
        public string Code { get;}

        public double[] Prices { get; set; }
        public int[] Packs{ get; set; }

        public Product(string name, string code, double[] prices, int[] packs)
        {
            Name = name;
            Code = code;
            this.Prices = prices;
            this.Packs = packs;
        }
    }
}
