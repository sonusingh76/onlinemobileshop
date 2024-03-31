using MobileOnlineShopSystem.OrderMicroservice.Business_Layer.DTO;
using MobileOnlineShopSystem.OrderMicroservice.Data_Access_Layer.Models;
using MobileOnlineShopSystem.UserMicroservice.Data_Access_Layer.Data;

namespace MobileOnlineShopSystem.OrderMicroservice.Data_Access_Layer.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly UserData _dbContext;

        public OrderRepository(UserData dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _dbContext.Orders.ToList();
        }

        public Order GetOrderById(int id)
        {
            return _dbContext.Orders.FirstOrDefault(o => o.Id == id);
        }

        public void AddOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                _dbContext.SaveChanges();
            }
        }

        public OrderDto GetUser(OrderDto order)
        {
            Order objorder = _dbContext.Orders.Where(x => x.UserId == order.UserId
            && x.MobileId == order.MobileId
            && x.CustomerName == order.CustomerName && x.CustomerEmail == order.CustomerEmail).OrderByDescending(y => y.Id).FirstOrDefault();

            OrderDto objOrderDto = new OrderDto();
            objOrderDto.Id = objorder.Id;
            return objOrderDto;
        }
    }
}

