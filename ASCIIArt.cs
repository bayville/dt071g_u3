namespace Guestbook
{
    public static class ASCIIArt
    {
        // ASCIIArt generated using https://www.asciiart.eu/text-to-ascii-art
        private static readonly string _filename = @"ascii-text-art.txt";
        private static readonly string _heading = "GÄSTBOK\n";

         // Method to display ASCII art or the heading if the file is empty or not found
        public static void Display()
        {
            try
            {
                if (File.Exists(_filename))
                {
                    string asciiArt = File.ReadAllText(_filename);

                    if (string.IsNullOrEmpty(asciiArt))
                    {
                        Console.WriteLine(_heading);
                    }
                    else
                    {
                        Console.WriteLine($"{asciiArt}\n\n");
                    }
                }
                else
                {
                    Console.WriteLine("Filen hittades inte. Visar rubrik istället:");
                    Console.WriteLine(_heading);
                }
            }
            catch (Exception )
            {
                Console.WriteLine(_heading);
            }
        }
    }
}
