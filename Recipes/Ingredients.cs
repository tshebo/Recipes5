using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

public class Recipe
{
    /*Fields

  /* private int ingredientAmount;
    private string[] ingredientNames;
    private double[] ingredientQuantity;
    private string[] ingredientUnits;
    private int stepAmount;
    private string[] stepDescriptions;
    private double scaleFactor;*/

    //new fields
    private string recipeName;

    private List<string> recipes;
    private List<string> names;
    private List<string> ingredients;
    private List<string> units;
    private List<double> quatities;
    private List<double> calories;
    private List<string> steps;
    private List<string> groups;
    private Dictionary<string, List<string>> singleRecipe;

    public string RecipeName { get => recipeName; set => recipeName = value; }
    public List<string> Recipes { get => recipes; set => recipes = value; }
    public List<string> Names { get => names; set => names = value; }
    public List<string> Ingredients { get => ingredients; set => ingredients = value; }
    public List<string> Units { get => units; set => units = value; }
    public List<double> Quatities { get => quatities; set => quatities = value; }
    public List<double> Calories { get => calories; set => calories = value; }
    public List<string> Steps { get => steps; set => steps = value; }
    public List<string> Groups { get => groups; set => groups = value; }
    public Dictionary<string, List<string>> SingleRecipe { get => singleRecipe; set => singleRecipe = value; }

    /*
    public Recipe(int ingredientAmount = 0)
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

    public double ScaleFactor { get => scaleFactor; set => scaleFactor = value; }
   */

    public void addIngredients()
    {
        // variables
        int i = 0;
        bool loop = true;
        string amount = "";
        double amount1 = 0;
        //intialize my lists
        Names = new List<string>();

        // Prompt for recipe name
        Console.Write("Enter recipe name: \t\t\t\t");
        Console.ForegroundColor = ConsoleColor.Blue;
        Names.Add(Console.ReadLine());
        Console.ForegroundColor = ConsoleColor.White;

        while (loop) //UNLIMITED AMOUNT OF INGREDIENTS
        { //Ingredients
            Console.WriteLine($"==== Ingredient {i + 1} ====");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Name of ingredient {i + 1}: \t\t\t\t");     //Name
            Console.ForegroundColor = ConsoleColor.Blue;
            string name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            do
            {
                Console.Write($"Amount of {name}(s): \t\t\t\t");      //Amount
                Console.ForegroundColor = ConsoleColor.Blue;
                amount = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                if (!double.TryParse(amount, out amount1))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (!double.TryParse(amount, out amount1));

            Groups.Add(foodGrp());                                          //Food Group

            Console.Write("Press 'N' to stop or any other key to continue: "); //break out of the loop
            Console.ForegroundColor = ConsoleColor.Blue;
            if (Console.ReadKey(true).Key == ConsoleKey.N)
            {
                loop = false;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            i++;
        }
    }

    public string foodGrp()
    {
        string[] grps = new string[7] { "Starchy", "Fruits and Veg", "Dry beans, peas, lentils and soya", "Meat / Chicken/ Fish", "Milk and dairy products", "Fats and oils", "Water" };

        bool isValidInput = false;
        int groupIndex = 0;
        string output = "";

        while (!isValidInput)  //checks for errors and reprompts
        {
            Console.WriteLine("Food group:");   //dispaly the grps array
            for (int i = 0; i < grps.Length; i++)
            {
                Console.WriteLine($"({i + 1}) {grps[i]}");
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            string input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            isValidInput = int.TryParse(input, out groupIndex); //store the input accordingly

            if (!isValidInput || groupIndex < 1 || groupIndex > grps.Length)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a number corresponding to the food group.");
                Console.ForegroundColor = ConsoleColor.White;
                isValidInput = false;
            }
        }

        output = grps[groupIndex - 1];
        // Groups.Add(grps[groupIndex - 1]);

        return output;
    }

    /* public void addSteps()
     {
         if (ingredientAmount > 0)
         {
             Console.WriteLine("===== Input Steps =====");
             // Prompt for number of steps
             Console.ForegroundColor = ConsoleColor.White;

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

         // Check if there are any ingredients
         if (IngredientNames == null || IngredientNames.Length == 0)
             {
             Console.ForegroundColor = ConsoleColor.DarkRed;
             display += "Error: No ingredients found for this recipe.\n";
             Console.ForegroundColor = ConsoleColor.White;
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

         return display;
         }

     public void Scale()
     {
          Console.WriteLine("Input 1 OR 2 \n(1)Scale Ingredients\n(2)Reset Scale \nAny Key to Exit");

          Console.ForegroundColor = ConsoleColor.Blue;

          double choice;
          if (double.TryParse(Console.ReadLine(), out choice))
          {
              Console.ForegroundColor = ConsoleColor.White;
              if (choice == 1)
              {
                 string input = "";

                 double scale;
                 // Ask user for scaling factor

                 Console.Write("Enter the scaling amount or press 'N' to cancel");

                 input = Console.ReadLine();

                 //Assign the input to the scaleFactor variable
                 if (input.ToUpper().Equals("N"))
                 {
                     //Dont Scale
                     Console.WriteLine(displayRecipe());
                 }
                 else if (double.TryParse(input, out scale))
                 {
                     //Scale the recipe according to the user input
                     this.scaleFactor = scale;
                     Console.WriteLine(displayRecipe(this.scaleFactor));
                 }
                 else
                 {
                     Console.ForegroundColor = ConsoleColor.DarkRed;
                     //error message
                     Console.WriteLine("Enter a Valid Input!!");
                     Console.ForegroundColor = ConsoleColor.White;
                 }
             }
              else if (choice == 2)
              {
                  double reset = 1.0;
                  displayRecipe(reset);
              }
              else
              {
                 Console.ForegroundColor = ConsoleColor.DarkRed;
                 Console.WriteLine("Invalid input.");
                 Console.ForegroundColor = ConsoleColor.White;
             }
          }
          else
          {
             Console.ForegroundColor = ConsoleColor.DarkRed;
             Console.WriteLine("Invalid input.");
             Console.ForegroundColor = ConsoleColor.White;
         }
     }

     public void Clear()
         {
         Console.ForegroundColor= ConsoleColor.Red;
         Console.WriteLine("To Confirm Clearing Press Y\n Press any Key to Cancel");
         string confirm = Console.ReadLine();

         if (confirm.Equals("Y"))
         {
             this.IngredientAmount = 0;
             this.StepAmount = 0;
             this.recipeName = null;

             Console.ForegroundColor= ConsoleColor.Green;
             Console.WriteLine("Data has been Cleared");
         }
         else
         {
             Console.ForegroundColor = ConsoleColor.Green;
             Console.WriteLine("Clearing Aborted");
         }

         Console.ForegroundColor = ConsoleColor.White;
      }

     */
}