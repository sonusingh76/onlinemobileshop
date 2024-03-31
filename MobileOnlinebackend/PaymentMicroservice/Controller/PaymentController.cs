using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileOnlineShopSystem.PaymentMicroservice.Business_Layer.DTO;
using MobileOnlineShopSystem.PaymentMicroservice.Business_Layer.Service;

namespace MobileOnlineShopSystem.PaymentMicroservice.Controller
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("{paymentId}")]
        public ActionResult<PaymentDto> GetPaymentById(int paymentId)
        {
            try
            {
                var payment = _paymentService.GetPaymentById(paymentId);
                if (payment == null)
                {
                    return NotFound();
                }

                return Ok(payment);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("orders/{orderId}")]
        public ActionResult<IEnumerable<PaymentDto>> GetPaymentsByorderId(int orderId)
        {
            try
            {
                var payments = _paymentService.GetPaymentsByOrderId(orderId);
                return Ok(payments);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddPayment(PaymentDto paymentDto)
        {
            try
            {
                _paymentService.AddPayment(paymentDto);
                return Ok();

            }
            catch (DbUpdateException ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine(ex.ToString());

                // Get the inner exception and include its message in the response
                var innerException = ex.InnerException;
                var errorMessage = innerException?.Message ?? "An error occurred while processing the payment. Please try again later.";

                // Return the error message
                return BadRequest(errorMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }
           
        }
    }
}

