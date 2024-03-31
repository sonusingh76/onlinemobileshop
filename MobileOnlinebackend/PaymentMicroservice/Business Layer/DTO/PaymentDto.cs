using MobileOnlineShopSystem.OrderMicroservice.Data_Access_Layer.Models;

namespace MobileOnlineShopSystem.PaymentMicroservice.Business_Layer.DTO
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
       // public int UserId { get; set; }

        public int OrderId { get; set; }
        public DateTime PaymentDate { get; set; }
        
    }
}

