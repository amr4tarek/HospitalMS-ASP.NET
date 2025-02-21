using hospitalManagement.Application.Dtos;
using hospitalManagement.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Interfaces.Services
{
    public interface IInvoiceService
    {
        Task<Result<InvoiceDto>> GetInvoiceByIdAsync(Guid id);
        Task<Result<IEnumerable<InvoiceDto>>> GetInvoicesByPatientIdAsync(Guid patientId);
        Task<Result<InvoiceDto>> CreateInvoiceAsync(InvoiceDto invoiceDto);
        Task<Result<InvoiceDto>> UpdateInvoiceAsync(InvoiceDto invoiceDto);
        Task<Result<bool>> DeleteInvoiceAsync(Guid id);
    }
}
