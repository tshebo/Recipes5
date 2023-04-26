internal class Program
{
    static bool loop = true;
    
    private static void Main(string[] args)
    {
       while(loop)
        {
            Menu();
        } 
    }
    static string Menu()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("=============================Welcome to the recipe app choose between the provided options==============================");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nEnter the number of the action you would like to perform");
        Console.WriteLine("(1) Add ingredients");
        Console.WriteLine("(2) Add steps");
        Console.WriteLine("(3) Display recipe ");
        Console.WriteLine("(4) Scale Recipe")
        Console.WriteLine("(5) Clear Data ");
        Console.WriteLine("Any key to Exit");

        Console.ForegroundColor = ConsoleColor.Blue;
        return Console.ReadLine();
    }

    static void validateChoice(string menu)
    {
        if (menu.Equals("1"))
        {

        }
        else if(menu.Equals("2"))
        {

        }
        else if (menu.Equals("3"))
        {

        }
        else if (menu.Equals("4"))
        {

        }
        else if (menu.Equals("5"))
        {

        }
        else{

        }
    }

    
}