using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace HttpClientSample
{

    public class Fields
    {
        public string siret { get; set; }
        public string nomen_long { get; set; }
        public string l1_normalisee { get; set; }


    }

    public class Records
    {
        public string recordid { get; set; }
        public Fields fields { get; set; }
    }


    public class Product
    {
        public int nhits { get; set; }
        public Records[] records { get; set; }
        /*   public string parameters { get; set; }
            public decimal Price { get; set; }
            public string Category { get; set; }*/
    }

    class Program
    {
        static HttpClient client = new HttpClient();

        static void ShowProduct(Product product)
        {
       /*     Console.WriteLine($"Name: {product.Name}\tPrice: " +
                $"{product.Price}\tCategory: {product.Category}");*/
        }

        /*  static async Task<Uri> CreateProductAsync(Product product)
          {
              var serializer = new JavaScriptSerializer();
              var json = serializer.Serialize(product);
              var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
              HttpResponseMessage response = await client.GetAsync(
                  "api/products", product);
              response.EnsureSuccessStatusCode();

              // return URI of the created resource.
              return response.Headers.Location;
    }*/

        static async Task<Product> GetProductAsync(string path)
        {
            Product product = null;
            String lrequest = "siren=" + "788975100";
            String lweb = String.Format("https://data.opendatasoft.com/api/records/1.0/search/?dataset=sirene%40public&q={0}", lrequest);
            HttpResponseMessage response = await client.GetAsync(lweb);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Product>();
            }
            return product;
        }


        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            //client.BaseAddress = new Uri("https://data.opendatasoft.com/api/records/1.0/search/");
            client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(
             //   new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new product
             Product product = new Product
                {
                   //Name = "Gizmo",
                 //   Price = 100,
             //       Category = "Widgets"
                };

                

                // Get the product
                product = await GetProductAsync("rien");
          

                // Update the product

           //     product.Price = 80;
            //    await UpdateProductAsync(product);

                // Get the updated product
               // product = await GetProductAsync(url.PathAndQuery);
             //   ShowProduct(product);

                // Delete the product
             //   var statusCode = await DeleteProductAsync(product.Id);
              //  Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}