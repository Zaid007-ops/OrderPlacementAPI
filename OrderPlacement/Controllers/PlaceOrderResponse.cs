namespace OrderPlacement.Controllers
{
    public class PlaceOrderResponse
    {
        public PlaceOrderResponse(string m)
        {
            this.Message = m;
        }

        public PlaceOrderResponse(string m, int id) : this(m)
        {
            this.Id = id;
        }

        public  int Id { get; set; }
        public string Message { get; set; }
    }
}