using HB_CampaingModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HB_CampaingModule.Commands
{
    public class CreateOrderCommand : ICommand
    {
        private string _productCode;
        private int _quantity;
        private List<Product> _productList;
        private List<Order> _orderList;

        public CreateOrderCommand(string productCode,int quantity,List<Product> productList,List<Order> orderList)
        {
            _productCode = productCode;
            _quantity = quantity;
            _productList = productList;
            _orderList = orderList;
        }
        public string ExecuteCommand()
        {

            var order = new Order
            {
                ProductCode = _productCode,
                Quantity = _quantity
            };

            var product = _productList.FirstOrDefault(p => p.ProductCode == _productCode);

            if (product == null)
            {
                return $"No product found with given productCode {_productCode}";
            }

            var isStock =  product.DecreaseStock(_quantity);

            if (!isStock)
            {
                return $"Order could not be created!!! Insufficient Stock";
            }

            order.OrderTotal = product.CurrentPrice * _quantity;

            _orderList.Add(order);

            return $"Order created; product {product.ProductCode}, quantity {_quantity}";
        }
    }
}
