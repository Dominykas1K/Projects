﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_app
{
    public class Receipt
    {
        public static string GenerateRestaurantReceipt(Order order)
        {
            var receipt = new StringBuilder();
            receipt.AppendLine($"Restorano Cekis - Staliukas {order.Table.TableNumber}");
            receipt.AppendLine($"Data: {order.DateTime}");
            receipt.AppendLine("Prekes:");
            foreach (var item in order.OrderedItems)
            {
                receipt.AppendLine($"{item.Name} - {item.Price} EUR");
            }
            receipt.AppendLine($"Viso: {order.TotalPrice} EUR");
            return receipt.ToString();
        }

        public static string GenerateCustomerReceipt(Order order)
        {
            var receipt = new StringBuilder();
            receipt.AppendLine($"Kliento Cekis - Staliukas {order.Table.TableNumber}");
            receipt.AppendLine($"Data: {order.DateTime}");
            receipt.AppendLine("Prekes:");
            foreach (var item in order.OrderedItems)
            {
                receipt.AppendLine($"{item.Name} - {item.Price} EUR");
            }
            receipt.AppendLine($"Viso: {order.TotalPrice} EUR");
            return receipt.ToString();
        }

    }
}


