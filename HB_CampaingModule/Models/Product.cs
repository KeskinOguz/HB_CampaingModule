using System;
using System.Collections.Generic;
using System.Text;

namespace HB_CampaingModule.Models
{
    public class Product
    {
        public Product(string productCode,decimal price,int stock)
        {
            ProductCode = productCode;
            FirstPrice = price;
            CurrentPrice = price;
            Stock = stock;
        }
        public string ProductCode { get; set; }
        public decimal FirstPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public int Stock { get; set; }

        public bool DecreaseStock(int quantity)
        {

            var newStock = Stock - quantity;

            if (newStock <= 0)
            {
                return false;
            }

            Stock = newStock;

            return true;
        }

        public void SetPrice(int limit,decimal durationRate)
        {
            var limitPrice = (FirstPrice * limit) / 100;

            var discountPrice = Math.Round(limitPrice * durationRate);

            if (discountPrice > limitPrice)
            {
                discountPrice = limitPrice;
            }

            CurrentPrice -= discountPrice;

        }
    }
}
