﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
namespace Restaurant_app
{
    public class Menu
    {
        public List<MenuItems> Items { get; set; } = new List<MenuItems>();

        public void LoadMenuItems(string foodFilePath, string drinkFilePath)
        {
            if (File.Exists("C:\\Users\\Boss\\Desktop\\c#\\Github\\Projects\\Restaurant app\\Restaurant app\\FoodItems.json"))
            {
                var foodJson = File.ReadAllText("C:\\Users\\Boss\\Desktop\\c#\\Github\\Projects\\Restaurant app\\Restaurant app\\FoodItems.json");
                var foodItems = JsonSerializer.Deserialize<Dictionary<string, decimal>>(foodJson);
                foreach (var item in foodItems)
                {
                    Items.Add(new MenuItems(item.Key, item.Value));
                }
            }
            else
            {
                Console.WriteLine("food file not found");
            }

            if (File.Exists("C:\\Users\\Boss\\Desktop\\c#\\Github\\Projects\\Restaurant app\\Restaurant app\\DrinkItems.json"))
             
            {
                var drinkJson = File.ReadAllText("C:\\Users\\Boss\\Desktop\\c#\\Github\\Projects\\Restaurant app\\Restaurant app\\DrinkItems.json");
                var drinkItems = JsonSerializer.Deserialize<Dictionary<string, decimal>>(drinkJson);
                foreach (var item in drinkItems)
                {
                    Items.Add(new MenuItems(item.Key, item.Value));
                }
            }

        }
    }
}
