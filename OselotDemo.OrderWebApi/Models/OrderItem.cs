

using OselotDemo.OrderWebApi.models;

namespace OselotDemo.OrderWebApi.Models
{
    public class OrderItem{
       public  Product? Product { get; set; }
       public int? Quantity {  get; set; }
    };
}
