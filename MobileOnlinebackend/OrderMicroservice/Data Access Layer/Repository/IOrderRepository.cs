using MobileOnlineShopSystem.OrderMicroservice.Business_Layer.DTO;
using MobileOnlineShopSystem.OrderMicroservice.Data_Access_Layer.Models;

namespace MobileOnlineShopSystem.OrderMicroservice.Data_Access_Layer.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
        OrderDto GetUser(OrderDto order);
    }
}
