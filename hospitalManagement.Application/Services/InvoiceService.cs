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
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<InvoiceDto>> GetInvoiceByIdAsync(Guid id)
        {
            var invoice = await _unitOfWork.Invoices.GetByIdAsync(id);
            if (invoice == null)
                return Result<InvoiceDto>.FailureResult("Invoice not found");
            var dto = _mapper.Map<InvoiceDto>(invoice);
            return Result<InvoiceDto>.SuccessResult(dto, "Invoice retrieved successfully");
        }

        public async Task<Result<IEnumerable<InvoiceDto>>> GetInvoicesByPatientIdAsync(Guid patientId)
        {
            var invoices = await _unitOfWork.Invoices.GetInvoicesByPatientIdAsync(patientId);
            var dtos = _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
            return Result<IEnumerable<InvoiceDto>>.SuccessResult(dtos, "Invoices retrieved successfully");
        }

        public async Task<Result<InvoiceDto>> CreateInvoiceAsync(InvoiceDto invoiceDto)
        {
            var invoice = _mapper.Map<Domain.Models.Invoice>(invoiceDto);
            await _unitOfWork.Invoices.AddAsync(invoice);
            await _unitOfWork.CommitAsync();
            var createdDto = _mapper.Map<InvoiceDto>(invoice);
            return Result<InvoiceDto>.SuccessResult(createdDto, "Invoice created successfully");
        }

        public async Task<Result<InvoiceDto>> UpdateInvoiceAsync(InvoiceDto invoiceDto)
        {
            var invoice = await _unitOfWork.Invoices.GetByIdAsync(invoiceDto.Id);
            if (invoice == null)
                return Result<InvoiceDto>.FailureResult("Invoice not found");
            _mapper.Map(invoiceDto, invoice);
            await _unitOfWork.Invoices.UpdateAsync(invoice);
            await _unitOfWork.CommitAsync();
            var updatedDto = _mapper.Map<InvoiceDto>(invoice);
            return Result<InvoiceDto>.SuccessResult(updatedDto, "Invoice updated successfully");
        }

        public async Task<Result<bool>> DeleteInvoiceAsync(Guid id)
        {
            var invoice = await _unitOfWork.Invoices.GetByIdAsync(id);
            if (invoice == null)
                return Result<bool>.FailureResult("Invoice not found");
            await _unitOfWork.Invoices.DeleteAsync(invoice);
            await _unitOfWork.CommitAsync();
            return Result<bool>.SuccessResult(true, "Invoice deleted successfully");
        }
    }
}
