using hospitalManagement.Application.Dtos;
using hospitalManagement.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Interfaces.Services
{
    public interface IStripePaymentService
    {
        Task<Result<PaymentDto>> ProcessStripePaymentAsync(PaymentDto paymentDto);
    }
}
