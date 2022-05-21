using HB_CampaingModule.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB_CampaingModule.Commands
{
    public class CreateCampaignCommand : ICommand
    {
        private string _name;
        private string _productCode;
        private int _duration;
        private int _limit;
        private int _targetSalesCount;
        private List<Campaign> _campaigns;
        public CreateCampaignCommand(string name,string productCode,int duration,int limit,int targetSalesCount,List<Campaign> campaigns)
        {
            _name = name;
            _productCode = productCode;
            _duration = duration;
            _limit = limit;
            _targetSalesCount = targetSalesCount;
            _campaigns = campaigns;
        }
        public string ExecuteCommand()
        {
            var campaign = new Campaign
            {
                Name = _name,
                ProductCode = _productCode,
                Duration = _duration,
                PriceManipulationLimit = _limit,
                TargetSalesCount = _targetSalesCount,
            };

            _campaigns.Add(campaign);

            return $"Campaign created; name {_name}, product {_productCode}, duration {_duration}, limit {_limit}, target sales count {_targetSalesCount}";
        }
    }
}
