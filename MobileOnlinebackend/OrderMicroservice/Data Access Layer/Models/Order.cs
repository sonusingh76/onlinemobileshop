using MobileOnlineShopSystem.MobileMicroservice.Data_Access_Layer.Models;
using MobileOnlineShopSystem.UserMicroservice.Data_Access_Layer.Models;

namespace MobileOnlineShopSystem.OrderMicroservice.Data_Access_Layer.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int MobileId { get; set; }
        public int UserId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsShipped { get; set; }
        public User User { get; set; }
        public Mobile Mobile { get; set; }
    }
}
