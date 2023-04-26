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
        Console.WriteLine("\nWhat would you like to do?");
        Console.WriteLine("1. Add ingredients");
        Console.WriteLine("2. Add steps");
        Console.WriteLine("3. Display recipe ");
        Console.WriteLine("4. Clear Data ");
        Console.WriteLine("Any key to Exit");

        Console.ForegroundColor = ConsoleColor.Blue;
        return Console.ReadLine();
    }

    
}