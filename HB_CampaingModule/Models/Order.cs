using System;
using System.Collections.Generic;
using System.Text;

namespace HB_CampaingModule.Models
{
    public class Order
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public decimal OrderTotal { get; set; }
    }

}
