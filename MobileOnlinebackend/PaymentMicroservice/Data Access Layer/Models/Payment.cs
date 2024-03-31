using MobileOnlineShopSystem.OrderMicroservice.Data_Access_Layer.Models;
using MobileOnlineShopSystem.UserMicroservice.Data_Access_Layer.Models;

namespace MobileOnlineShopSystem.PaymentMicroservice.Data_Access_Layer.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
      //  public int UserId { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        // Navigation properties for relationships
       public virtual Order Order { get; set; }
    }
}
