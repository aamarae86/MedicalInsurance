using Abp.Domain.Services;
using ERP.StripeIntegration.Models;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP.StripeIntegration
{
    public interface IStripeService : IDomainService
    {
        Task<Session> CreatePayment(PaymentInput model);
        Task<bool> CheckIfPaymentSuccess(string SessionId);
    }
}
