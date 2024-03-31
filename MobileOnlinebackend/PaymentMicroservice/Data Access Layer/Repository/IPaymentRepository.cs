using MobileOnlineShopSystem.PaymentMicroservice.Data_Access_Layer.Models;

namespace MobileOnlineShopSystem.PaymentMicroservice.Data_Access_Layer.Repository
{
    public interface IPaymentRepository
    {
        Payment GetPaymentById(int paymentId);
        IEnumerable<Payment> GetPaymentsByOrderId(int orderId);
        void AddPayment(Payment payment);
    }
}

