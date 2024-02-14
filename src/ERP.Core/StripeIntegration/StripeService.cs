using ERP.StripeIntegration.Models;
using Microsoft.Extensions.Configuration;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP.StripeIntegration
{
    public class StripeService : IStripeService
    {
        string Secretkey = "";
        string Publishablekey = "";

        public StripeService(IConfiguration configuration)
        {
            Secretkey = configuration["StripeApiData:Secretkey"];
            Publishablekey = configuration["StripeApiData:Publishablekey"];
        }
        //public PaymentIntent TestIntegration()
        //{
        //    // Set your secret key. Remember to switch to your live secret key in production.
        //    // See your keys here: https://dashboard.stripe.com/account/apikeys
        //    //   StripeConfiguration.ApiKey = "sk_test_4eC39HqLyjWDarjtT1zdp7dc";
        //    StripeConfiguration.ApiKey = "sk_test_51IaKSPD0nmYaono5nGJBlwgma0fQgzxcZJVKjhyPTBEA4TbErgTTScyoHQuPi3ATxDJgUdAcBYOBKZQMXPbvvg8S00g6Na0G1t";
        //    var options = new PaymentIntentCreateOptions
        //    {
        //        Amount = 1000,
        //        Currency = "usd",
        //        PaymentMethodTypes = new List<string>
        //          {
        //            "card",
        //          },
        //        ReceiptEmail = "amr.mohamed0eg@gmail.com",
        //    };

        //    var service = new PaymentIntentService();
        //    var paymentIntent = service.Create(options);
        //    return paymentIntent;
        //}



        public async Task<Session> CreatePayment(PaymentInput model)
        {
            var domain = model.Domain;
            StripeConfiguration.ApiKey = Secretkey;

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                  "card",
                },
                LineItems = new List<SessionLineItemOptions>
                {
                  new SessionLineItemOptions
                  {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                      UnitAmount = model.UnitAmount * 100 ,
                      Currency = !string.IsNullOrEmpty(model.Currency) ? model.Currency : "usd",
                      ProductData = new SessionLineItemPriceDataProductDataOptions
                      {
                        Name = model.ProductName
                      },
                    },
                    Quantity = model.Quantity,
                  },
                },
                Mode = "payment",
                SuccessUrl = domain + "/Tenant/success",
                CancelUrl = domain + "/Tenant",
            };
            var service = new SessionService();
            Session session = await service.CreateAsync(options);
            return session;

        }

        public async Task<bool> CheckIfPaymentSuccess(string SessionId)
        {
            var service = new SessionService();
            var paymentSession = await service.GetAsync(SessionId);
            if (paymentSession.PaymentStatus== "paid")
            {
                return true;
            }
            return false;
        }
    }
}
