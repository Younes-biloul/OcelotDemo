namespace OselotDemo.OrderWebApi.models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        public Product(int productId, string productName, string description, decimal price, int stockQuantity)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
            this.Price = price;
            this.StockQuantity = stockQuantity;
        }


    }

}
