using AutoMapper;
using hospitalManagement.Application.Dtos;
using hospitalManagement.Application.Helpers;
using hospitalManagement.Application.Interfaces.Services;
using hospitalManagement.Application.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<PaymentDto>> GetPaymentByIdAsync(Guid id)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(id);
            if (payment == null)
                return Result<PaymentDto>.FailureResult("Payment not found");
            var dto = _mapper.Map<PaymentDto>(payment);
            return Result<PaymentDto>.SuccessResult(dto, "Payment retrieved successfully");
        }

        public async Task<Result<IEnumerable<PaymentDto>>> GetPaymentsByInvoiceIdAsync(Guid invoiceId)
        {
            var invoice = await _unitOfWork.Invoices.GetByIdAsync(invoiceId);
            if (invoice == null)
                return Result<IEnumerable<PaymentDto>>.FailureResult("Invoice not found");
            var dtos = _mapper.Map<IEnumerable<PaymentDto>>(invoice.Payments);
            return Result<IEnumerable<PaymentDto>>.SuccessResult(dtos, "Payments retrieved successfully");
        }

        public async Task<Result<PaymentDto>> ProcessPaymentAsync(PaymentDto paymentDto)
        {
            var payment = _mapper.Map<Domain.Models.Payment>(paymentDto);
            await _unitOfWork.Payments.AddAsync(payment);
            await _unitOfWork.CommitAsync();
            var createdDto = _mapper.Map<PaymentDto>(payment);
            return Result<PaymentDto>.SuccessResult(createdDto, "Payment processed successfully");
        }
    }
}
