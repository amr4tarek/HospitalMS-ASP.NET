using hospitalManagement.Application.Dtos;
using hospitalManagement.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<Result<PaymentDto>> GetPaymentByIdAsync(Guid id);
        Task<Result<IEnumerable<PaymentDto>>> GetPaymentsByInvoiceIdAsync(Guid invoiceId);
        Task<Result<PaymentDto>> ProcessPaymentAsync(PaymentDto paymentDto);
    }
}
