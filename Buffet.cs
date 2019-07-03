using System;
using System.Collections.Generic;

namespace iron_ninja {
    class Buffet
    {
        public List<IConsumable> Menu;
        
        //constructor
        public Buffet()
        {
            Menu = new List<IConsumable>()
            {
                new Food("Burrito", 1000, true, false),
                new Food("Pasghetti", 1200, true, true),
                new Food("Icecream Sundae", 1000, false, true),
                new Food("Sammich", 2000, true, true),
                new Food("Hot Cheeto tacos", 1000, true, false),
                new Food("Sushi", 1000, true, false),
                new Food("Crazy noodles", 1000, false, true),
            };
        }
        public IConsumable Serve()
        {
            Random rand = new Random();
            int x = rand.Next(Menu.Count);
            return Menu[x];
        }
    }
}