using MobileOnlineShopSystem.OrderMicroservice.BusinessLayer.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using MobileOnlineShopSystem.OrderMicroservice.Business_Layer.DTO;
using MobileOnlineShopSystem.OrderMicroservice.Business_Layer.Service;
using MobileOnlineShopSystem.UserMicroservice.Data_Access_Layer.Models;

namespace MobileOnlineShopSystem.OrderMicroservice.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _orderService.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        public IActionResult PlaceOrder(OrderDto orderDto)
        {
            try
            {
                _orderService.PlaceOrder(orderDto);
                OrderDto obj = _orderService.GetUser(orderDto);
                return Ok(new { OrderId = obj.Id});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, OrderDto orderDto)
        {
            try
            {
                if (id != orderDto.Id)
                {
                    return BadRequest("Order ID mismatch.");
                }

                _orderService.UpdateOrder(orderDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                _orderService.DeleteOrder(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
