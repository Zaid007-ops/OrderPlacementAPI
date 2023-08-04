using Newtonsoft.Json;
using OrderPlacement.Controllers;

namespace OrderPlacement.Products
{
    public class ProductsRepository
    {
        public List<Product> RetriveProducts()
        {
            HttpResponseMessage response = new HttpClient().GetAsync("https://gateway.api.testing.zen.co.uk/training-api/ProductAvailability/").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Product API call failed");
            }
            var data = response.Content.ReadAsStringAsync().Result;
            var AllProducts = JsonConvert.DeserializeObject<List<Product>>(data);
            return AllProducts;
        }
    }
}
