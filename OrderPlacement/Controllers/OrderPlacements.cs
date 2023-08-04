using Microsoft.AspNetCore.Mvc;
using OrderPlacement.Database;
using OrderPlacement.Products;

namespace OrderPlacement.Controllers
{
    [Route("api/Orders")]
    [ApiController]
    public class OrderPlacements : ControllerBase
    {
        [HttpGet(Name = "OrderPlacement")]
        public List<Order> GetOrders()
        {
            return new DatabaseRepository().GetOrders();
        }

        [HttpPost(Name = "OrderPlacement")]
        public PlaceOrderResponse PlaceOrder(PlaceOrderRequest request)
        {
            var AllProducts = new ProductsRepository().RetriveProducts();
            var IsProductAvailable = AllProducts?.Any(P => P.Available && P.Code == request.ProductCode);
            var ProductOrdered = AllProducts?.FirstOrDefault(P => P.Code == request.ProductCode);

            Random random = new Random();
            var Id = random.Next(1, 9999999);

            if (IsProductAvailable == true)
            {
                new DatabaseRepository().SaveToDatabase(request, ProductOrdered, Id);
                return new PlaceOrderResponse("Order Placed" , Id);
            }
            else
            {
                return new PlaceOrderResponse("Order Failed");
            }
        }

        
    }
}
