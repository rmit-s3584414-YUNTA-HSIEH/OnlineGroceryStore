using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace OnlinegGroceryStore
{
    class OnlineStore
    {
        private ArrayList products;

        public OnlineStore()
        {
            products = new ArrayList();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void Order(string order)
        {
            StringReader stReader = new StringReader(order);
            string line;
            
            while ((line = stReader.ReadLine()) != null)
            {
                string[] words = line.Split(' ');
                int orderNum = Int32.Parse(words[0]);
                var temp = from Product p in products where p.Code == words[1] select p; 
                if(temp != null)
                {
                    Product product = temp.ElementAt(0);
                    int[] specificPack = Calculator(product.Packs, orderNum);
                    ResultString(product.Code,product.Packs, specificPack, product.Prices,orderNum);
                }
            }


        }

        private int[] Calculator(int[] packs, int order)
        {
            int[] array = new int[order + 1];
            int index = 0;
            for (int i = 0; i <= order; i++)
            {
                array[i] = (Int32.MaxValue - 1);
            }
            array[0] = 0;
            //use dynamic programming to calculate the minimum number of packs  
            for (int i = 0; i < packs.Length; i++)
            {
                for (int j = packs[i]; j <= order; j++)
                {
                    array[j] = Math.Min(array[j], array[j - packs[i]] + 1);
                    if (j == order && array[j - packs[i]] != Int32.MaxValue - 1)
                    {
                        index = i;
                    }
                }
            }
            //to know the specific pack be used in how many times
            int[] specificPack = new int[packs.Length];

            for (int i = array[order]; i > 0;)
            {
                if (order - packs[index] < 0 || (array[order - packs[index]] == Int32.MaxValue - 1 && (order - packs[index]) != 0))
                {
                    index -= 1;
                    continue;
                }
                specificPack[index]++;
                i--;
                order -= packs[index];
            }

            return specificPack;
        }

        private void ResultString(string code, int[] originalPacks,int[]Calculatedkpacks, double[] prices, int orderNum)
        {
            double total = 0;
            string result = null;

            for (int i = 0; i < Calculatedkpacks.Length; i++)
            {
                result += Calculatedkpacks[i] + " *" + originalPacks[i]+" $" + prices[i]  + "\n";
                total += (Calculatedkpacks[i] * prices[i]);
            }

            result += orderNum + " " + code + " $" + total + "\n";

            Console.WriteLine(result);
        }
    }
}
