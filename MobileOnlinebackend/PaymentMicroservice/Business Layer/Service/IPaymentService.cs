using MobileOnlineShopSystem.PaymentMicroservice.Business_Layer.DTO;

namespace MobileOnlineShopSystem.PaymentMicroservice.Business_Layer.Service
{
    public interface IPaymentService
    {
        PaymentDto GetPaymentById(int paymentId);
        IEnumerable<PaymentDto> GetPaymentsByOrderId(int orderId);
        void AddPayment(PaymentDto paymentDto);
    }
}
