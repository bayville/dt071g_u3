namespace Guestbook
{
    public class ErrorHandler
    {

        // Method to display error message
        public void DisplayError(string errMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{errMessage}");
            Console.ResetColor();
        }

        // Metod to display message and wait for keypress
        public void WaitForKeyPress()
        {
            Console.WriteLine("Tryck på valfri knapp för att fortsätta...");
            Console.ReadKey();
        }
    }
}
