using MMT_Client.Entity;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MMT_Client.Utility
{
    public class ShowAllProduct : IProductResult
    {
        public async void Display(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var products = await response.Content.ReadAsAsync<List<Product>>();

                foreach (Product product in products)
                {
                    Console.WriteLine("{0}\t{1}\t{2} GBP", product.Name, product.Description, product.Price);
                }

                Console.ReadLine();
            }
        }

    }
}
