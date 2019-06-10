using System;

namespace OnlinegGroceryStore
{
    class Program
    {
        static void Main(string[] args)
        {
            //create products
            Product SlicedHam = new Product("Sliced Ham","SH3",new double[] {2.99,4.49},new int[] { 3,5});
            Product Yoghurt = new Product("Yoghurt", "YT2", new double[] { 4.95,9.95,13.95 }, new int[] { 4,10,15 });
            Product ToiletRolls = new Product("Toilet Rolls", "TR", new double[] { 2.95,4.45,7.99 }, new int[] { 3, 5,9 });

            OnlineStore store = new OnlineStore();
            //add product into store
            store.AddProduct(SlicedHam);
            store.AddProduct(Yoghurt);
            store.AddProduct(ToiletRolls);

            //test
            string order = "10 SH3 " + Environment.NewLine + "18 YT2" + Environment.NewLine + "12 TR";
            store.Order(order);
        }
    }
}
