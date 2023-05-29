using System;

internal class Program
{
    private static bool loop = true;
    private static RecipeManager recipe = new RecipeManager();
    public static string menu;

    private static void Main(string[] args)
    {
        while (loop)
        {
            validateChoice(Menu());
        }
    }

    private static string Menu()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("===== Welcome to the recipe app choose between the provided options =====");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nEnter the number of the action you would like to perform");
        Console.WriteLine("(1) Add Recipe");
        Console.WriteLine("(2) Add steps");
        Console.WriteLine("(3) Display recipe ");
        Console.WriteLine("(4) Scale Recipe");
        Console.WriteLine("(5) Delete Data ");
        Console.WriteLine("Any key to Exit");

        Console.ForegroundColor = ConsoleColor.Blue;
        menu = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;

        //menu = choice;
        return menu;
    }

    public static void validateChoice(string menu)
    {
        if (menu.Equals("1"))
        {
            // Add Recipe option
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("===== Add Recipe =====");
            Console.ForegroundColor = ConsoleColor.White;
            recipe.AddIngredients();
        }
        else if (menu.Equals("2"))
        {
            // Add Steps option
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("===== Add Steps =====");
            Console.ForegroundColor = ConsoleColor.White;
            recipe.AddSteps();
        }
        else if (menu.Equals("3"))
        {
            // Display Recipe option
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("===== Display Recipe =====");
            Console.WriteLine(recipe.DisplayRecipe());
            Console.ForegroundColor = ConsoleColor.White;
        }
        else if (menu.Equals("4"))
        {
            // Scaling Options option
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("===== Scaling Options =====");
            Console.ForegroundColor = ConsoleColor.White;
            recipe.Scale();
        }
        else if (menu.Equals("5"))
        {
            // Clear Data option
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("===== Delete Recipe =====");
            Console.ForegroundColor = ConsoleColor.White;
            recipe.DeleteRecipe();
        }
        else
        {
            // Confirm exit
            string confirm;
            string exit = menu;
            Console.WriteLine($"Are you sure that you want to exit? Press '{exit}' again to confirm OR any other key to continue");
            Console.ForegroundColor = ConsoleColor.Red;
            confirm = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            if (confirm.Equals(exit))
            {
                Exit();
            }
        }
    }

    public static bool Exit()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Exiting the application.");
        Environment.Exit(0);
        loop = false;
        Console.ForegroundColor = ConsoleColor.White;
        return loop;
    }
}