using hospitalManagement.Application.Dtos;
using hospitalManagement.Application.Helpers;
using hospitalManagement.Application.Interfaces.Services;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Services
{
    
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task NotifyPaymentStatusAsync(PaymentDto paymentDto)
        {
            // Broadcast to all connected clients (or use groups/users as needed)
            await _hubContext.Clients.All.SendAsync("ReceivePaymentStatus", paymentDto);
        }

        public async Task NotifyAppointmentUpdateAsync(AppointmentDto appointmentDto)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveAppointmentUpdate", appointmentDto);
        }
    }
}
