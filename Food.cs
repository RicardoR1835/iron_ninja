using System;
using System.Collections.Generic;

namespace iron_ninja {
    class Food : IConsumable
    {
        public string Name {get;set;}
        public int Calories {get;set;}
        public bool IsSpicy {get;set;}
        public bool IsSweet {get;set;}
        public string GetInfo()
        {
            return $"{Name} (Food).  Calories: {Calories}.  Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
        }
        public Food(string name, int cals, bool spice, bool sweets){
            Name = name;
            Calories = cals;
            IsSpicy = spice;
            IsSweet = sweets;
        }
    } 
}