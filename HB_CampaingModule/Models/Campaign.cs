using System;
using System.Collections.Generic;
using System.Text;

namespace HB_CampaingModule.Models
{
    public class Campaign
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public int PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
        public bool Status { get; set; } = true;
    }
}
