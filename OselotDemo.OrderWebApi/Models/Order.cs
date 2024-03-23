namespace OselotDemo.OrderWebApi.Models
{
    public class Order
    {
        public int? OrderId { get; set; }
        public string? CustomerName { get; set; }
        public DateTime? OrderDate { get; set; }
        private decimal? TotalAmount {  get; set; }
        public List<OrderItem>? OrderItems { get; set; }

        public Order()
        {
            this.TotalAmount = OrderItems.Sum(item => item.Product.Price * item.Quantity);
        }

        
    }

}
