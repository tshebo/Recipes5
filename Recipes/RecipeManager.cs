using System;
using System.Collections.Generic;

public class RecipeManager
{
    private Dictionary<string, Recipe> recipeCollection;
    public int count;

    public Dictionary<string, Recipe> RecipeCollection { get => recipeCollection; set => recipeCollection = value; }

    public void AddIngredients()
    {
        count = 0;
        RecipeCollection = new Dictionary<string, Recipe>();

        // Prompt user to enter recipe name
        Console.Write("Enter recipe name: \t\t");
        Console.ForegroundColor = ConsoleColor.Blue;
        string recipeName = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;

        Recipe recipe = new Recipe();
        recipe.Name = recipeName;

        bool loop = true;
        int i = 0;

        while (loop)
        {
            Console.WriteLine($"==== Ingredient {i + 1} ====");
            Console.ForegroundColor = ConsoleColor.White;
            // Prompt user to enter ingredient name
            Console.Write($"Name of ingredient {i + 1}: \t\t");
            Console.ForegroundColor = ConsoleColor.Blue;
            string ingredientName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            recipe.Ingredients.Add(ingredientName);

            double amount;
            bool validAmount = false;
            do
            {
                // Prompt user to enter ingredient amount
                Console.Write($"Amount of {ingredientName}(s): \t\t");
                Console.ForegroundColor = ConsoleColor.Blue;
                string input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                if (!double.TryParse(input, out amount))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    validAmount = true;
                    recipe.Quantities.Add(amount);
                }
            } while (!validAmount);

            // Prompt user to enter ingredient unit
            string unit;
            Console.Write($"Unit of measurement for {ingredientName}(s):\t");
            Console.ForegroundColor = ConsoleColor.Blue;
            unit = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            recipe.Units.Add(unit);

            double calory;
            bool validCalories = false;
            do
            {
                // Prompt user to enter ingredient calories
                Console.Write("Amount of calories: \t\t");
                Console.ForegroundColor = ConsoleColor.Blue;
                string input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                if (!double.TryParse(input, out calory))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    validCalories = true;
                    recipe.Calories.Add(calory);
                }
            } while (!validCalories);

            string group = FoodGroup();
            recipe.Groups.Add(group);

            Console.Write("Press 'N' to stop adding or any other key to continue: \n");
            Console.ForegroundColor = ConsoleColor.Blue;
            // Check if the user wants to stop adding ingredients
            if (Console.ReadKey(true).Key == ConsoleKey.N)
            {
                RecipeCollection.Add(recipeName, recipe);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Recipe was captured \n");
                Console.ForegroundColor = ConsoleColor.White;
                count++;

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
            // Display food groups for selection
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
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input. Please enter a number corresponding to the food group.");
                Console.ForegroundColor = ConsoleColor.White;
                isValidInput = false;
            }
        }

        output = groups[groupIndex - 1];
        return output;
    }

    public string RecipeNames()
    {
        int index = 0;
        int i = 0;
        string chosen = null;
        bool validChoice = false;

        if (count != 0)
        {
            do
            {
                i = 0;
                foreach (var recipe in RecipeCollection.Values)
                {
                    Console.WriteLine($"({i + 1}) {recipe.Name}");
                    i++;
                }

                Console.WriteLine("Choose a recipe:");
                string input = Console.ReadLine();

                if (int.TryParse(input, out index))
                {
                    index--;

                    if (index >= 0 && index < RecipeCollection.Count)
                    {
                        validChoice = true;
                        break;
                    }
                }

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Enter the correct input.");
                Console.ForegroundColor = ConsoleColor.White;
            } while (true);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Unable to proceed without ingredients!!!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        if (validChoice)
        {
            chosen = RecipeCollection.Values.ElementAt(index).Name;
        }

        return chosen;
    }

    public void AddSteps()
    {
        string chosen = RecipeNames();

        if (!string.IsNullOrEmpty(chosen))
        {
            Console.WriteLine($"Adding steps for recipe {chosen}");

            // Retrieve the selected recipe object from the RecipeCollection
            Recipe selectedRecipe = RecipeCollection[chosen];

            int i = 0;
            string step = "";
            string exit = "";

            do
            {
                Console.Write($"Step {i + 1}: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                step = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                selectedRecipe.Steps.Add(step);

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Press 'N' to stop adding or any other key to continue: \n");
                Console.ForegroundColor = ConsoleColor.Blue;
                exit = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            } while (exit.ToUpper() != "N");
        }
    }
}