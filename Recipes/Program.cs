internal class Program
{
    static bool loop = true;
    static Recipe recipe = new Recipe();
    
    private static void Main(string[] args)
    {
       while(loop)
        {
           validateChoice(Menu());
        } 
    }
    static string Menu()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("===== Welcome to the recipe app choose between the provided options =====");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nEnter the number of the action you would like to perform");
        Console.WriteLine("(1) Add ingredients");
        Console.WriteLine("(2) Add steps");
        Console.WriteLine("(3) Display recipe ");
        Console.WriteLine("(4) Scale Recipe");
        Console.WriteLine("(5) Clear Data ");
        Console.WriteLine("Any key to Exit");

        Console.ForegroundColor = ConsoleColor.Blue;
        return Console.ReadLine();
    }

    public static void validateChoice(string menu)
    {
        if (menu.Equals("1"))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("===== Add Ingredients =====");
            Console.ForegroundColor = ConsoleColor.White;
            recipe.getIngredients();
        }
        else if(menu.Equals("2"))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("===== Add Steps =====");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else if (menu.Equals("3"))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("===== Display Recipe =====");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else if (menu.Equals("4"))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("===== Scaling Options =====");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else if (menu.Equals("5"))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("===== Clear Data =====");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else{
            Exit();
        }
    }

    public static bool Exit()
    {
        Console.ForegroundColor= ConsoleColor.DarkRed;
        Console.WriteLine("Exiting the recipe app.");
        Environment.Exit(0);
        loop = false;
        Console.ForegroundColor = ConsoleColor.White;
        return loop;
    }

    
}