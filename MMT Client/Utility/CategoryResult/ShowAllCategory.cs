using MMT_Client.Entity;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MMT_Client.Utility.CategoryResult
{
    public class ShowAllCategory : ICategoryResult
    {
        public async void Display(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var Categories = await response.Content.ReadAsAsync<List<Category>>();

                foreach (Category category in Categories)
                {
                    Console.WriteLine("{0}", category.Name);
                }

                Console.ReadLine();
            }
        }
    }
}
