namespace OrderPlacement.Controllers
{
    public class Order
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public string Customer { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
