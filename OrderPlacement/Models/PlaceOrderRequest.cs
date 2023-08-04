
namespace OrderPlacement.Controllers
{
    public class PlaceOrderRequest
    {
        public string ProductCode { get; set; }

        public Customer Customer { get; set; }

    }
}
