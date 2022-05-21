using HB_CampaingModule.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB_CampaingModule.Commands
{
    public class CreateProductCommand : ICommand
    {
        private string _code;
        private decimal _price;
        private int _stock;
        private List<Product> _productList;
        public CreateProductCommand(string code,decimal price,int stock,List<Product> productList)
        {
            _code = code;
            _price = price;
            _stock = stock;
            _productList = productList;
        }
        public string ExecuteCommand()
        {

            var product = new Product(_code, _price, _stock);

            _productList.Add(product);

            return $"Product created; code {_code}, price {_price}, stock {_stock}";
        }
    }
}
