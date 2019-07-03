using System;
using System.Collections.Generic;

namespace iron_ninja
{
   interface IConsumable
    {
        string Name {get;set;}
        int Calories {get;set;}
        bool IsSpicy {get;set;}
        bool IsSweet {get;set;}
        string GetInfo();
    } 
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

    class Drink : IConsumable
    {
        public string Name {get;set;}
        public int Calories {get;set;}
        public bool IsSpicy {get;set;}
        public bool IsSweet {get;set;}
        
        public string GetInfo()
        {
            return $"{Name} (Food).  Calories: {Calories}.  Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
        }

        public Drink(string name, int cals, bool spice, bool sweets){
            Name = name;
            Calories = cals;
            IsSpicy = spice;
            IsSweet = sweets;
        }
    } 
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
    abstract class Ninja
    {
        protected int calorieIntake;
        public List<IConsumable> ConsumptionHistory;
        
        
        public Ninja()
        {
            calorieIntake = 0;
            ConsumptionHistory = new List<IConsumable>();
        }
        
        
        public abstract bool isFull {get;}
        
        public abstract void Consume(IConsumable item);
    }

    class SweetTooth : Ninja
    {
           public override bool isFull
           {
               get { return calorieIntake >= 1500;}
           }

        public override void Consume(IConsumable item)
        {
            if(isFull == false){
                Console.WriteLine(calorieIntake);
                ConsumptionHistory.Add(item);
                Console.WriteLine($"Ninja ate {item.Name}");
                calorieIntake += item.Calories;
                Console.WriteLine(calorieIntake);
                if(item.IsSweet){
                        calorieIntake += 10;
                }
                Console.WriteLine(item.GetInfo());
                Console.WriteLine(calorieIntake);
                Console.WriteLine($"Yoo dis ninja ate {item.Name}, if you're wondering if it's spicy: {item.IsSpicy}, and if you're wondering if its sweet: {item.IsSweet}");
            } else {
                Console.WriteLine("Sweet tooth is too full homie");
            }
        }
    }
    class SpiceHound : Ninja
        {
            public override bool isFull
            {
                get { return calorieIntake >= 1200;}
            }

            
            public override void Consume(IConsumable item)
            {
                if(isFull == false){
                    Console.WriteLine(calorieIntake);
                    ConsumptionHistory.Add(item);
                    Console.WriteLine($"Ninja ate {item.Name}");
                    calorieIntake += item.Calories;
                    Console.WriteLine(calorieIntake);
                    if(item.IsSpicy){
                        calorieIntake -= 5;
                    }

                    Console.WriteLine(item.GetInfo());
                    Console.WriteLine(calorieIntake);
                    Console.WriteLine($"Yoo dis ninja ate {item.Name}, if you're wondering if it's spicy: {item.IsSpicy}, and if you're wondering if its sweet: {item.IsSweet}");
                } else {
                    Console.WriteLine("Spice Hound is way too full homie");
                }
            }
        }
    
    class Program
    {
        static void Main(string[] args)
        {
            Buffet menu = new Buffet();
            IConsumable x = menu.Serve();
            IConsumable y = menu.Serve();
            IConsumable z = menu.Serve();
            SpiceHound rick = new SpiceHound();
            SweetTooth dave = new SweetTooth();
            dave.Consume(x);
            rick.Consume(x);
            dave.Consume(y);
            rick.Consume(y);
        
        }
    }
}
