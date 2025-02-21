using hospitalManagement.Application.Dtos;
using hospitalManagement.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IStripePaymentService _stripePaymentService;
        private readonly INotificationService _notificationService;

        public PaymentController(IPaymentService paymentService,
                                 IStripePaymentService stripePaymentService,
                                 INotificationService notificationService)
        {
            _paymentService = paymentService;
            _stripePaymentService = stripePaymentService;
            _notificationService = notificationService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPayment(Guid id)
        {
            var result = await _paymentService.GetPaymentByIdAsync(id);
            if (!result.Success) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet("invoice/{invoiceId}")]
        public async Task<IActionResult> GetPaymentsByInvoice(Guid invoiceId)
        {
            var result = await _paymentService.GetPaymentsByInvoiceIdAsync(invoiceId);
            return Ok(result);
        }

        [HttpPost("process")]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentDto paymentDto)
        {
            var stripeResult = await _stripePaymentService.ProcessStripePaymentAsync(paymentDto);
            if (!stripeResult.Success)
            {
                return BadRequest(stripeResult.Message);
            }

            var paymentResult = await _paymentService.ProcessPaymentAsync(stripeResult.Data);

            // Optionally notify clients via SignalR.
            if (paymentResult.Success)
            {
                await _notificationService.NotifyPaymentStatusAsync(paymentResult.Data);
            }

            return Ok(paymentResult);
        }
    }
}
