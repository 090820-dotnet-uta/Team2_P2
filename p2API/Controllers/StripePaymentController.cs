using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Stripe;

namespace p2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripePaymentController : ControllerBase
    {

        [HttpPost]
        public PaymentIntent CreateCharge()
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = 10,
                Currency = "usd",
                PaymentMethodTypes = new List<string> {
                                "card",
                 },
            };

            var service = new PaymentIntentService();
            var intent = service.Create(options);

            return intent;
        }
    }
}

