using hospitalManagement.Application.Dtos;
using hospitalManagement.Application.Helpers;
using hospitalManagement.Application.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Services
{
    public class StripePaymentService : IStripePaymentService
    {
        private readonly string _apiKey;

        public StripePaymentService(IConfiguration configuration)
        {
            _apiKey = configuration["Stripe:SecretKey"];
            StripeConfiguration.ApiKey = _apiKey;
        }

        public async Task<Result<PaymentDto>> ProcessStripePaymentAsync(PaymentDto paymentDto)
        {
            var paymentIntentService = new PaymentIntentService();
            PaymentIntent paymentIntent;

            // Create PaymentIntent
            try
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)(paymentDto.AmountPaid * 100), 
                    Currency = "usd",
                    Description = "Hospital Payment",
                };

                paymentIntent = await paymentIntentService.CreateAsync(options);
            }
            catch (StripeException ex)
            {
                return Result<PaymentDto>.FailureResult($"Stripe error: {ex.Message}");
            }

            paymentDto.StripeChargeId = paymentIntent.Id;
            paymentDto.PaymentMethod = "Stripe"; 

            return Result<PaymentDto>.SuccessResult(paymentDto, "Payment processed successfully via Stripe");
        }
    }
}
