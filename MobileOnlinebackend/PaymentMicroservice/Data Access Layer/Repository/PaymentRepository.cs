using MobileOnlineShopSystem.PaymentMicroservice.Data_Access_Layer.Models;
using MobileOnlineShopSystem.PaymentMicroservice.Data_Access_Layer.Repository;
using MobileOnlineShopSystem.UserMicroservice.Data_Access_Layer.Data;
using System.Collections.Generic;
using System.Linq;

namespace MobileOnlineShopSystem.PaymentMicroservice.DataAccessLayer.RepositoryImplementation
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly UserData _dbContext;

        public PaymentRepository(UserData dbContext)
        {
            _dbContext = dbContext;
        }

        public Payment GetPaymentById(int paymentId)
        {
            return _dbContext.Payments.FirstOrDefault(p => p.PaymentId == paymentId);
        }

        public IEnumerable<Payment> GetPaymentsByOrderId(int orderId)
        {
            return _dbContext.Payments.Where(p => p.OrderId == orderId).ToList();
        }

        public void AddPayment(Payment payment)
        {
            _dbContext.Payments.Add(payment);
            _dbContext.SaveChanges();
        }

       
    }
}
