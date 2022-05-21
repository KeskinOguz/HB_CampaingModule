using HB_CampaingModule.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB_CampaingModule.Commands
{
    public class IncreaseTimeCommand : ICommand
    {
        private readonly List<Product> _productList;
        private readonly List<Campaign> _campaignList;
        private readonly TimeSpan _timeSpan;

        public IncreaseTimeCommand(List<Product> productList, List<Campaign> campaignList,TimeSpan timeSpan)
        {
            _productList = productList;
            _timeSpan = timeSpan;
            _campaignList = campaignList;
        }
        public string ExecuteCommand()
        {

            foreach (var campaign in _campaignList)
            {
                var durationRate = Convert.ToDecimal(_timeSpan.TotalHours / campaign.Duration);

                var product = _productList.Find(p => p.ProductCode == campaign.ProductCode);

                product.SetPrice(campaign.PriceManipulationLimit, durationRate);

                if (_timeSpan.Hours >= campaign.Duration)
                {
                    campaign.Status = false;
                }

            }

            return $"Time is {_timeSpan:hh\\:mm}";
        }
    }
}
