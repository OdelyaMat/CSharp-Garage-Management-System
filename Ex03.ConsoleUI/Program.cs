namespace Ex03.ConsoleUI
{
    // $G$ SFN-999 (-5) When loading data from file throws an exception of failed loading. It still add all the successfully parsed vehicle to the garage.
    public class Program
    {
        public static void Main()
        {
            GarageApplication app = new GarageApplication();
            app.Run();
        }
    }
}
