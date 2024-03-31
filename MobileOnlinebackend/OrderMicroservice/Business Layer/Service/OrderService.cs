using MobileOnlineShopSystem.MobileMicroservice.Business_Layer.DTO;
using MobileOnlineShopSystem.MobileMicroservice.Data_Access_Layer.Models;
using MobileOnlineShopSystem.OrderMicroservice.Business_Layer.DTO;
using MobileOnlineShopSystem.OrderMicroservice.Business_Layer.Service;
using MobileOnlineShopSystem.OrderMicroservice.Data_Access_Layer.Models;
using MobileOnlineShopSystem.OrderMicroservice.Data_Access_Layer.Repository;
using MobileOnlineShopSystem.UserMicroservice.Data_Access_Layer.Models;
using System.Collections.Generic;

namespace MobileOnlineShopSystem.OrderMicroservice.BusinessLayer.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<OrderDto> GetAllOrders()
        {
            var orders = _orderRepository.GetAllOrders();
            var orderDtos = new List<OrderDto>();

            foreach (var order in orders)
            {
                var orderDto = new OrderDto
                {
                    Id = order.Id,
                    MobileId = order.MobileId,
                    UserId = order.UserId,
                    CustomerName = order.CustomerName,
                    CustomerEmail = order.CustomerEmail,
                    ShippingAddress = order.ShippingAddress,
                    OrderDate = order.OrderDate,
                    IsShipped = order.IsShipped
                 
                };

                orderDtos.Add(orderDto);
            }

            return orderDtos;
        }

        public OrderDto GetOrderById(int id)
        {
            var order = _orderRepository.GetOrderById(id);

            if (order == null)
            {
                // Handle not found case or throw an exception
                return null;
            }
            var orderDto = new OrderDto
            {
                Id = order.Id,
                MobileId = order.MobileId,
                UserId = order.UserId,
                CustomerName = order.CustomerName,
                CustomerEmail = order.CustomerEmail,
                ShippingAddress = order.ShippingAddress,
                OrderDate = order.OrderDate,
                IsShipped = order.IsShipped,

            };

            return orderDto;
        }

        public void PlaceOrder(OrderDto orderDto)
        {
            var order = new Order
            {
                Id = orderDto.Id,
                MobileId = orderDto.MobileId,
                UserId = orderDto.UserId,
                CustomerName = orderDto.CustomerName,
                CustomerEmail = orderDto.CustomerEmail,
                ShippingAddress= orderDto.ShippingAddress,
                OrderDate = orderDto.OrderDate,
                IsShipped= orderDto.IsShipped

             
            };

            _orderRepository.AddOrder(order);
            
        }

        public void UpdateOrder(OrderDto orderDto)
        {
            var order = new Order
            {
                Id = orderDto.Id,
                MobileId = orderDto.MobileId,
                UserId = orderDto.UserId,
                CustomerName = orderDto.CustomerName,
                CustomerEmail = orderDto.CustomerEmail,
                ShippingAddress = orderDto.ShippingAddress,
                OrderDate = orderDto.OrderDate,
                IsShipped = orderDto.IsShipped
            };

            _orderRepository.UpdateOrder(order);
           
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.DeleteOrder(id);
           
        }

        public OrderDto GetUser(OrderDto orderDto)
        {
            return _orderRepository.GetUser(orderDto);
        }
    }
}
