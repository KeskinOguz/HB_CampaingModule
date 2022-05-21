using HB_CampaingModule.Commands;
using HB_CampaingModule.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace HB_CampaingModule
{
    class Program
    {
        public static List<Product> _products;
        public static List<Campaign> _campaigns;
        public static List<Order> _orders;
        static void Main(string[] args)
        {
            ICommand command;

            TimeSpan ts = TimeSpan.FromHours(0);

            _products = new List<Product>();
            _campaigns = new List<Campaign>();
            _orders = new List<Order>();

            var commandlines = ReadCommands();

            foreach (var commandline in commandlines)
            {
                var splitCommands = commandline.Split(' ');

                switch (splitCommands[0])
                {
                    case "create_product":
                        command = new CreateProductCommand(code: splitCommands[1],price: Convert.ToDecimal(splitCommands[2]),stock: Convert.ToInt32(splitCommands[3]),_products);
                        break;
                    case "get_product_info":
                        command = new GetProductInfoCommand(productCode: splitCommands[1], _products);
                        break;
                    case "create_order":
                        command = new CreateOrderCommand(productCode: splitCommands[1],quantity: Convert.ToInt32(splitCommands[2]), _products, _orders);
                        break;
                    case "create_campaign":
                        command = new CreateCampaignCommand(name: splitCommands[1],productCode: splitCommands[2],duration: Convert.ToInt32(splitCommands[3]),limit: Convert.ToInt32(splitCommands[4]),targetSalesCount: Convert.ToInt32(splitCommands[5]), _campaigns);
                        break;
                    case "get_campaign_info":
                        command = new GetCampaignInfoCommand(name: splitCommands[1], _campaigns, _orders);
                        break;
                    case "increase_time":
                        ts += TimeSpan.FromHours(Convert.ToInt32(splitCommands[1]));
                        command = new IncreaseTimeCommand(_products,_campaigns,ts);
                        break;
                    default:
                        Console.WriteLine($"Unrecognized command detected!! - {splitCommands[0]}");
                        continue;
                }

                Console.WriteLine(command.ExecuteCommand());
            }

            Console.ReadLine();
             
        }


        public static string[] ReadCommands()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"commands.txt");
            string[] commands = File.ReadAllLines(path);
           
            return commands;
        }

    }
}
