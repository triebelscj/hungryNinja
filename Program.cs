using System;
using System.Collections.Generic;

namespace hungryNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffet buffet = new Buffet();
            Ninja ninja = new Ninja();

            while (!ninja.IsFull)
            {
                var food = buffet.Serve();
                ninja.Eat(food);
            }
            ninja.Eat(buffet.Serve());
            Console.WriteLine("ninja is full and cannot eat anymore!");
        }
    }
    class Food
    {
        public string Name;
        public int Calories;
        public bool IsSpicy;
        public bool IsSweet;

        public Food(string fName, int fCalories, bool fIsSpicy, bool fIsSweet)
        {
            Name = fName;
            Calories = fCalories;
            IsSpicy = fIsSpicy;
            IsSweet = fIsSweet;
        }
    }
    class Buffet
    {
        public List<Food> Menu;

        public Buffet()
        {
            Menu = new List<Food>()
            {
                new Food("tacos", 500, false, false),
                new Food("burrito", 1500, true, false),
                new Food("sushi", 550, false, true),
                new Food("sandwich", 300, false, false),
                new Food("spagetti", 800, true, true),
                new Food("steak", 200, false, false),
                new Food("torta", 1000, false, true),
            };
        }

        public Food Serve()
        {
            // Generate Random
            Random rand = new Random();
            // from Menu constructor
            var randomIndex = rand.Next(0, Menu.Count);
            // Returns value from Menu by random index
            return Menu[randomIndex];
        }
    }
    class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory;

        // add a constructor
        public Ninja(int calorieIntake = 0)
        {
            FoodHistory = new List<Food>();
        }
        // add a public "getter" property called "IsFull"
        public bool IsFull
        {
            get
            {
                if (calorieIntake > 5500)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // build out the Eat method
        public void Eat(Food item)
        {
            if (!IsFull)
            {
                calorieIntake += item.Calories;
                FoodHistory.Add(item);
                Console.WriteLine($"{item.Name}: Spicy? {item.IsSpicy}; Sweet? {item.IsSweet}; Calories so far? {calorieIntake} ");
            }
            else
            {
                Console.WriteLine("The ninja is full and cannot eat anymore!");
            }
        }
    }
}
