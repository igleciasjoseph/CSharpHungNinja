using System;
using System.Collections.Generic;

namespace HungryNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Ninja n1 = new Ninja();
            Buffet b1 = new Buffet();
            Food f1 = new Food("Salad", 2000, false, true);
            f1.Display();
            n1.Display();
        }
    }

    class Food {
        public string Name;
        public int Calories;
        public bool isSpicy;
        public bool isSweet;

        public Food(string Name, int Calories, bool isSpicy, bool isSweet) {
            this.Name = Name;
            this.Calories = Calories;
            this.isSpicy = isSpicy;
            this.isSweet = isSweet;
        }

        public void Display() {
            string res = "";
            res += $"Name: {Name}\n";
            res += $"Calories: {Calories}\n";
            res += $"Spicy: {isSpicy}\n";
            res += $"Sweet: {isSweet}\n";
            res += "--------------------";

            Console.WriteLine(res);
        }
    }

    class Buffet {
        public List<Food> Menu;

        public Buffet() {
            Menu = new List<Food>() {
                new Food("Sushi", 1000, true, true),
                new Food("Oreos", 400, false, true),
                new Food("Ritz", 400, false, true),
                new Food("Spicy Tuna", 300, true, true),
                new Food("Snickers", 200, false, true),
                new Food("Chips Ahoy", 500, false, true)
            };
        }

        public Food Serve(){
            Random rand = new Random();
            int RandSelect = rand.Next(0, Menu.Count);
            return Menu[RandSelect];
        }
    }

    class Ninja {
        private int CalorieIntake;
        public List<Food> FoodHistory;

        public Ninja(){
            this.CalorieIntake = 0;
            this.FoodHistory = new List<Food>();
        }

        public bool isFull {
            get {
                if (CalorieIntake > 1200) {
                    return true;
                } else {
                    return false;
                }
            }
        }



        public void Eat(Food Item){
            if (!this.isFull) {
                CalorieIntake += Item.Calories;
                FoodHistory.Add(Item);
                Console.WriteLine(Item.Name);
                if (Item.isSpicy || Item.isSweet) {
                    Console.WriteLine(Item.isSpicy);
                    Console.WriteLine(Item.isSweet);
                }
            } else {
                Console.WriteLine("Sorry, Ninja is Full!");
            }
        }

        public void Display() {
            string res = "";
            res += $"Full: {isFull}";
            Console.WriteLine(res);
        }
    }
}
