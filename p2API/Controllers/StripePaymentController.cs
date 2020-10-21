using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Stripe;

namespace p2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripePaymentController : Controller
    {

        [HttpPost]
        public IActionResult Post([FromBody] StripePaymentRequest paymentRequest)
        {
            StripeConfiguration.ApiKey = "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";

            var myCharge = new ChargeCreateOptions();
            myCharge.Source = paymentRequest.tokenId;
            myCharge.Amount = paymentRequest.amount;
            myCharge.Currency = "usd";
            myCharge.Description = paymentRequest.productName;
            myCharge.Metadata = new Dictionary<string, string>();
            myCharge.Metadata["OurRef"] = "OurRef-" + Guid.NewGuid().ToString();

            var chargeService = new ChargeService();
            var stripeCharge = chargeService.Create(myCharge);

            return Json(stripeCharge);
        }

        public class StripePaymentRequest
        {
            public string tokenId { get; set; }
            public string productName { get; set; }
            public int amount { get; set; }
            
        }
    }
}

