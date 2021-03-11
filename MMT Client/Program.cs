using MMT_Client.Utility;
using MMT_Client.Utility.CategoryResult;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MMT_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            IProductResult productResult = null;
            ICategoryResult categoryResult = null;
            HttpResponseMessage response = new HttpResponseMessage();
            DisplayResult displayResult = DisplayResult.AllCategory; //By default, change for different report

            using (var client = new HttpClient())
            {
                //------Code  Start to  test Web API-------

                client.BaseAddress = new Uri("https://localhost:44384/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                switch (displayResult)
                {
                    case DisplayResult.AllProduct:
                        productResult = new ShowAllProduct();
                        response = await client.GetAsync("api/product");
                        productResult.Display(response);
                        break;
                    case DisplayResult.ProductByCategory:
                        productResult = new ShowByCategoryId();
                        response = await client.GetAsync("api/category/1/product"); //Default categoryid set to 1
                        productResult.Display(response);
                        break;
                    case DisplayResult.AllCategory:
                        categoryResult = new ShowAllCategory();
                        response = await client.GetAsync("api/category");
                        categoryResult.Display(response);
                        break;
                }

            }
        }
    }
}
