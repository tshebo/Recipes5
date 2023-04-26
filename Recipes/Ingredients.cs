using System.ComponentModel;

public class Recipe
{
    // Fields
    private string recipeName;
    private int ingredientAmount;
    private string[] ingredientNames;
    private double[] ingredientQuantity;
    private string[] ingredientUnits;
    private int stepAmount;
    private string[] stepDescriptions;
    private double scaleFactor;

    // Constructor
    public Recipe(int ingredientAmount =0)
    {
        this.ingredientAmount = ingredientAmount;
        this.ingredientNames = new string[ingredientAmount];
        this.ingredientQuantity = new double[ingredientAmount];
        this.ingredientUnits = new string[ingredientAmount];
    }

    // Properties
    public int IngredientAmount { get => ingredientAmount; set => ingredientAmount = value; }
    public string[] IngredientNames { get => ingredientNames; set => ingredientNames = value; }
    public double[] IngredientQuantity { get => ingredientQuantity; set => ingredientQuantity = value; }
    public string[] IngredientUnits { get => ingredientUnits; set => ingredientUnits = value; }
    public int StepAmount { get => stepAmount; set => stepAmount = value; }
    public string[] StepDescriptions { get => stepDescriptions; set => stepDescriptions = value; }
    public string RecipeName { get => recipeName; set => recipeName = value; }
    public double ScaleFactor { get => scaleFactor; set => scaleFactor = value; }

    public void addIngredients()
    {
        // Prompt for recipe name
        Console.Write("Enter recipe name: \t\t\t\t");
        Console.ForegroundColor = ConsoleColor.Blue;
        RecipeName = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;

        // Prompt for number of ingredients
        
        Console.Write("How many ingredients would you like to add? \t");
        Console.ForegroundColor = ConsoleColor.Blue;
        while (!int.TryParse(Console.ReadLine(), out ingredientAmount) || ingredientAmount <= 0)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Invalid input. Please enter a positive integer.");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("How many ingredients would you like to add? \t");
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        IngredientAmount = ingredientAmount;

        // Initialize arrays
        IngredientNames = new string[IngredientAmount];
        IngredientQuantity = new double[IngredientAmount];
        IngredientUnits = new string[IngredientAmount];

        // Store ingredients
        for (int i = 0; i < IngredientAmount; i++)
        {
            Console.WriteLine($"==== Ingredient {i + 1} ====");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Name of ingredient {i + 1}: \t\t\t\t");
            Console.ForegroundColor = ConsoleColor.Blue;
            IngredientNames[i] = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            double quantity;
            Console.Write($"Amount of {IngredientNames[i]}(s): \t\t\t\t");
            Console.ForegroundColor = ConsoleColor.Blue;
            while (!double.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input. Please enter a positive number.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Amount of {IngredientNames[i]}(s):\t\t\t\t ");
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            IngredientQuantity[i] = quantity;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Unit of measurement for {IngredientNames[i]}(s):\t\t");
            Console.ForegroundColor = ConsoleColor.Blue;
            IngredientUnits[i] = Console.ReadLine();

        }

       
    }
    public void addSteps()
    {
        if (ingredientAmount > 0)
        {
            Console.WriteLine("===== Input Steps =====");
            // Prompt for number of steps
            Console.ForegroundColor = ConsoleColor.White;

            int amount;
            Console.Write("How many steps would you like to add? ");
            Console.ForegroundColor = ConsoleColor.Blue;
            while (!int.TryParse(Console.ReadLine(), out stepAmount) || stepAmount <= 0)
            {

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input. Please enter a positive integer.!!!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("How many steps would you like to add? ");
            }
            StepAmount = stepAmount;
            Console.ForegroundColor = ConsoleColor.White;
            // Initialize array
            StepDescriptions = new string[StepAmount];

            // Store steps
            for (int i = 0; i < StepAmount; i++)
            {
                Console.Write($"Step {i + 1}: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                StepDescriptions[i] = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("You can't add steps without Ingredients!!!");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
   
        //Display Recipe
        public string displayRecipe(double scaleFactor = 1)
        {
        
            Console.ForegroundColor = ConsoleColor.Yellow;

            string display = "";

         if(IngredientAmount <=0) {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("There is nothing to display");
            Console.ForegroundColor = ConsoleColor.White;

            return "";
        }
        
          
        

        // Check if t-here are any ingredients
        if (IngredientNames == null || IngredientNames.Length == 0)
            {
                display += "Error: No ingredients found for this recipe.\n";
                return display;
            }

            // Display recipe name
            display += $"Name: {RecipeName}\n\n";

            // Display ingredients
            display += "Ingredients:\n";
            for (int i = 0; i < IngredientAmount; i++)
            {
                display += $"{scaleFactor * IngredientQuantity[i]} {IngredientUnits[i]} {IngredientNames[i]}\n";
            }

            // Display steps
            display += "\nSteps:\n";
            for (int i = 0; i < StepAmount; i++)
            {
                display += $"{i + 1}. {StepDescriptions[i]}\n";
            }
            //Console.WriteLine(display);
        
      




        return display;
        
        }
}
