using ERP.StripeIntegration;
using ERP.StripeIntegration.Models;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Payment
{
    public class PaymentAppService: IPaymentAppService
    {
        private readonly IStripeService _stripeService;

        public PaymentAppService(IStripeService stripeService)
        {
            _stripeService = stripeService;
        }

         public async Task<Session> CreatePayment(PaymentInput model)
        {
            try
            {
              var PaymentSession= await  _stripeService.CreatePayment(model);
              return PaymentSession;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
