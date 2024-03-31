using MobileOnlineShopSystem.OrderMicroservice.Business_Layer.DTO;

namespace MobileOnlineShopSystem.OrderMicroservice.Business_Layer.Service
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetAllOrders();
        OrderDto GetOrderById(int id);
        void PlaceOrder(OrderDto orderDto);
        void UpdateOrder(OrderDto orderDto);
        void DeleteOrder(int id);

        OrderDto GetUser(OrderDto orderDto);
    }
}
