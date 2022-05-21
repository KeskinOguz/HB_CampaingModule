using HB_CampaingModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HB_CampaingModule.Commands
{
    public class GetCampaignInfoCommand : ICommand
    {
        private string _name;
        private List<Campaign> _campaignList;
        private List<Order> _orderList;
        public GetCampaignInfoCommand(string name,List<Campaign> campaignList,List<Order> orderList)
        {
            _name = name;
            _campaignList = campaignList;
            _orderList = orderList;
        }
        public string ExecuteCommand()
        {
            var campaign = _campaignList.Find(c => c.Name == _name);

            if (campaign == null)
            {
                return $"No campaign found with given name {_name}";
            }

            var filterOrderList = _orderList.Where(o => o.ProductCode == campaign.ProductCode).ToList();

            int totalSalesCount = 0;
            decimal turnover = 0;
       

            foreach (var order in filterOrderList)
            {
                totalSalesCount += order.Quantity;
                turnover += order.OrderTotal;
            }

            decimal avgPrice = 0;

            if (totalSalesCount > 0)
            {
                 Math.Round(turnover / totalSalesCount);
            }

         
            return $"Campaign {_name} info; Status {(campaign.Status == true ? "Aktive" : "Ended")}, Target Sales {campaign.TargetSalesCount}, Total Sales {totalSalesCount},Turnover {turnover} Average Item Price {avgPrice}";
        }
    }
}
