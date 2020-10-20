using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
  public class StripeCharge
    {
      
            public long Amount { get; set; }
            public string Currency { get; set; }
            public string Source { get; set; }
            public string ReceiptEmail { get; set; }
        }
    }

