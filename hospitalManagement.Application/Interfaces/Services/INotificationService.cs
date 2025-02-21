using hospitalManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Interfaces.Services
{
    public interface INotificationService
    {
        Task NotifyPaymentStatusAsync(PaymentDto paymentDto);
        Task NotifyAppointmentUpdateAsync(AppointmentDto appointmentDto);
    }
}
