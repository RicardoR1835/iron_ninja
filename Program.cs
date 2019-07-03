using System;
using System.Collections.Generic;

namespace iron_ninja
{
   
    

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
            dave.Consume(x);
            rick.Consume(x);
            rick.Consume(y);
            rick.Consume(z);
            Console.WriteLine(rick.ConsumptionHistory.Count);
            Console.WriteLine(dave.ConsumptionHistory.Count);
            if(rick.ConsumptionHistory.Count > dave.ConsumptionHistory.Count){
                Console.WriteLine("Rick ate more thangs");
            } else{
                Console.WriteLine("Dave is the man i guess");
            }
        }
    }
}
