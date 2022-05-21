using HB_CampaingModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HB_CampaingModule.Commands
{
    public class GetProductInfoCommand : ICommand
    {
        private string _productCode;
        private List<Product> _productList;
        public GetProductInfoCommand(string productCode,List<Product> productList)
        {
            _productCode = productCode;
            _productList = productList;
        }
        public string ExecuteCommand()
        {
            var product = _productList.FirstOrDefault(p => p.ProductCode == _productCode);

            if (product == null)
            {
                return $"No product found with given productCode {_productCode}";
            }

            return $"Product {product.ProductCode} info; price {product.CurrentPrice}, stock {product.Stock}";
        }
    }
}
