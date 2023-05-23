using System;
using System.Collections.Generic;

public class Recipe
{
    // Fields
    private string recipeName;

    private List<string> names;
    private List<string> ingredients;
    private List<string> units;
    private List<double> quantities;
    private List<double> calories;
    private List<string> steps;
    private List<string> groups;
    private Dictionary<string, List<string>> singleRecipe;

    // Properties
    public string RecipeName { get => recipeName; set => recipeName = value; }

    public List<string> Names { get => names; set => names = value; }
    public List<string> Ingredients { get => ingredients; set => ingredients = value; }
    public List<string> Units { get => units; set => units = value; }
    public List<double> Quantities { get => quantities; set => quantities = value; }
    public List<double> Calories { get => calories; set => calories = value; }
    public List<string> Steps { get => steps; set => steps = value; }
    public List<string> Groups { get => groups; set => groups = value; }
    public Dictionary<string, List<string>> SingleRecipe { get => singleRecipe; set => singleRecipe = value; }

    public void AddIngredients()
    {
        // Initialize lists
        Names = new List<string>();
        Ingredients = new List<string>();
        Units = new List<string>();
        Quantities = new List<double>();
        Calories = new List<double>();

        // Prompt for recipe name
        Console.Write("Enter recipe name: ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Names.Add(Console.ReadLine());
        Console.ForegroundColor = ConsoleColor.White;

        bool loop = true;
        int i = 0;

        while (loop)
        {
            // Ingredient
            Console.WriteLine($"==== Ingredient {i + 1} ====");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Name of ingredient {i + 1}: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Ingredients.Add(name);

            // Amount
            double amount;
            bool validAmount = false;
            do
            {
                Console.Write($"Amount of {name}(s): ");
                Console.ForegroundColor = ConsoleColor.Blue;
                string input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                if (!double.TryParse(input, out amount))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    validAmount = true;
                    Quantities.Add(amount);
                }
            } while (!validAmount);

            // Calories
            double calories;
            bool validCalories = false;
            do
            {
                Console.Write("Amount of calories: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                string input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                if (!double.TryParse(input, out calories))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    validCalories = true;
                    Calories.Add(calories);
                }
            } while (!validCalories);

            // Food Group
            Console.Write("Press 'N' to stop or any other key to continue: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            if (Console.ReadKey(true).Key == ConsoleKey.N)
            {
                loop = false;
            }
            Console.ForegroundColor = ConsoleColor.White;

            i++;
        }
    }

    public string FoodGroup()
    {
        string[] groups = {
            "Starchy",
            "Fruits and Veg",
            "Dry beans, peas, lentils and soya",
            "Meat / Chicken/ Fish",
            "Milk and dairy products",
            "Fats and oils",
            "Water"
        };

        bool isValidInput = false;
        int groupIndex = 0;
        string input = "";
        string output = "";

        while (!isValidInput)
        {
            Console.WriteLine("Food group:");
            for (int i = 0; i < groups.Length; i++)
            {
                Console.WriteLine($"({i + 1}) {groups[i]}");
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            isValidInput = int.TryParse(input, out groupIndex);

            if (!isValidInput || groupIndex < 1 || groupIndex > groups.Length)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a number corresponding to the food group.");
                Console.ForegroundColor = ConsoleColor.White;
                isValidInput = false;
            }
        }

        output = groups[groupIndex - 1];
        return output;
    }
}