using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;

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
    private Dictionary<string, object> singleRecipe;
    private List<object> recipeCollection;
    public int count;

    // Properties
    public string RecipeName { get => recipeName; set => recipeName = value; }

    public List<string> Names { get => names; set => names = value; }
    public List<string> Ingredients { get => ingredients; set => ingredients = value; }
    public List<string> Units { get => units; set => units = value; }
    public List<double> Quantities { get => quantities; set => quantities = value; }
    public List<double> Calories { get => calories; set => calories = value; }
    public List<string> Steps { get => steps; set => steps = value; }
    public List<string> Groups { get => groups; set => groups = value; }
    public Dictionary<string, object> SingleRecipe { get => singleRecipe; set => singleRecipe = value; }
    public List<object> RecipeCollection { get => recipeCollection; set => recipeCollection = value; }

    public void AddIngredients()
    {
        //count = 0;

        // Initialize lists
        Names = new List<string>();
        Ingredients = new List<string>();
        Units = new List<string>();
        Quantities = new List<double>();
        Calories = new List<double>();
        Groups = new List<string>();
        SingleRecipe = new Dictionary<string, object>();
        RecipeCollection = new List<object>();

        // Prompt for recipe name
        Console.Write("Enter recipe name: \t\t");
        Console.ForegroundColor = ConsoleColor.Blue;
        recipeName = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        names.Add(recipeName);

        bool loop = true;
        int i = 0;

        while (loop)
        {
            // Ingredient
            Console.WriteLine($"==== Ingredient {i + 1} ====");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Name of ingredient {i + 1}: \t\t");
            Console.ForegroundColor = ConsoleColor.Blue;
            string name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Ingredients.Add(name);

            // Quantity
            double amount;
            bool validAmount = false;
            do
            {
                Console.Write($"Amount of {name}(s): \t\t");
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
                    Quantities.Add(amount);
                }
            } while (!validAmount);

            //units
            string unit;
            Console.Write($"Unit of measurement for {name}(s):\t");
            Console.ForegroundColor = ConsoleColor.Blue;
            unit = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            units.Add(unit);

            // Calories
            double calory;
            bool validCalories = false;
            do
            {
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
                    calories.Add(calory);
                }
            } while (!validCalories);

            // Food Group
            string group = FoodGroup();
            groups.Add(group);

            //User chooses to continue or stop the procedure
            Console.Write("Press 'N' to stop adding or any other key to continue: \n");
            Console.ForegroundColor = ConsoleColor.Blue;
            if (Console.ReadKey(true).Key == ConsoleKey.N)
            {
                //store the lists in a dictionary
                singleRecipe.Add("Name", recipeName);
                singleRecipe.Add("Ingredients", ingredients);
                singleRecipe.Add("Units", units);
                singleRecipe.Add("Quantities", quantities);
                singleRecipe.Add("Calories", Calories);
                singleRecipe.Add("Food Groups", groups);

                //Store Dictionary as a single recipe
                recipeCollection.Add(singleRecipe);

                // Success Message
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
        //variables
        int index = 0;
        string chosen = null;

        if (count != 0)  //check if there are any recipes saved
        {
            do   //do while loop checks for errors and reprompts
            {
                //Names.Sort(); //sort the names in alphabetical order

                // Display the sorted list of recipe names
                for (int x = 0; x < count; x++)
                {
                    Console.WriteLine($"({x + 1}) {Names[x]}");
                }
                Console.WriteLine();

                // Accept user input
                Console.ForegroundColor = ConsoleColor.Blue;
                string input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                int.TryParse(input, out index);

                //check if the user chose the correct option

                if (!int.TryParse(input, out index) || index > Names.Count)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Enter a valid input");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    // i want this function to access the recipe dictionary and return a recipe name
                    chosen = Names[index - 1];
                }
            } while (index <= 0 || index > Names.Count);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Unable to proceed without Ingredients!!!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        return chosen;
    }

    public void AddSteps()
    {
        //variables
        int i = 0;
        string step = "";
        string exit = "";
        string choice = RecipeNames();
        Steps = new List<string> { };

        Console.WriteLine($"Adding steps for recipe {choice}");
        do
        {
            // Get Steps
            Console.Write($"Step {i + 1}: ");
            Console.ForegroundColor = ConsoleColor.Blue;                                                        //st10038900
            step = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Steps.Add(step);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            //User chooses to continue or stop the procedure
            Console.Write("Press 'N' to stop adding or any other key to continue: \n");
            Console.ForegroundColor = ConsoleColor.Blue;
            if (Console.ReadKey(true).Key == ConsoleKey.N)
            {
                /// Retrieve the dictionary for the chosen recipe
                foreach (object item in recipeCollection)
                {
                }

                // Success Message
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Steps were captured \n");
                Console.ForegroundColor = ConsoleColor.White;

                ///loop = false;
            }
        } while (count > 0);
    }
}

//st10038900