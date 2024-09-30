
namespace Guestbook
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GuestbookController posts = new(); // Creates an instance of of GuestbookController
            ErrorHandler errorHandler = new(); // Creates an instance of ErrorHandler
            int i = 0; // Declares and int used in loop

            while (true)
            {
                Console.Clear();                            // Clears console
                Console.CursorVisible = false;              // Hides cursor
                int postsCount = posts.GetPosts().Count;    // Gets length of posts lists

                // Writes out menu-options
                Console.WriteLine("1. Skriv inlägg");

                // If there are posts in the list write out delete option
                if (postsCount > 0)
                {
                    Console.WriteLine("2. Radera inlägg");
                }

                Console.WriteLine("X. Avsluta\n");


                // Header for posts
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (postsCount <= 0)
                {
                    Console.WriteLine("Det finns inga inlägg i gästboken...");
                }
                else
                {
                    Console.WriteLine("Inlägg i gästboken:");
                }
                Console.ResetColor();


                // Loops and writes out all posts
                i = 0;
                foreach (Post post in posts.GetPosts())
                {
                    Console.WriteLine($"[{i}] {post.Author}: {post.Message}");
                    i++;
                }



                Console.WriteLine("\nAnge alternativ: ");
                int input = (int)Console.ReadKey(true).Key; // Gets user input and typecasts it to an INT

                Console.CursorVisible = true; // Makes cursor visible
                switch (input)
                {
                    case 49: // 49 = key 1

                        // Gets user input
                        Console.Write("Ange Namn: ");
                        string? author = Console.ReadLine();
                        Console.Write("Ange Meddelande: ");
                        string? message = Console.ReadLine();

                        // Checks if string is null or empty
                        if (!String.IsNullOrEmpty(author) && !String.IsNullOrEmpty(message))
                        {
                            try
                            {
                                posts.AddPost(author, message); // Adds new post using method AddPost
                            }
                            catch (Exception e)
                            {
                                // Writes out error message using custom error class
                                errorHandler.DisplayError($"Något gick fel: ${e.Message}");
                                errorHandler.WaitForKeyPress();
                            }
                        }
                        else
                        {
                            // Writes out error message using custom error class
                            errorHandler.DisplayError("Du måste fylla i både namn och meddelande");
                            errorHandler.WaitForKeyPress();
                        }
                        break;

                    case 50: // 50 = key 2
                        if (postsCount <= 0)
                        {
                            // Writes out error message using custom error class
                            errorHandler.DisplayError("Det finns inga inlägg att ta bort");
                            errorHandler.WaitForKeyPress();
                        }
                        else
                        {
                            Console.Write("Ange index för inlägg att ta bort: ");
                            string? inputIndex = Console.ReadLine();
                            try
                            {
                                int removeIndex = Convert.ToInt32(inputIndex); // Converts input string to integer
                                posts.RemovePost(removeIndex); // Removes post from list
                            }
                            catch (Exception)
                            {
                                // Writes out error message using custom error class
                                errorHandler.DisplayError("Index finns inte i listan, ange giltigt index");
                                errorHandler.WaitForKeyPress();
                            }
                        }
                        break;

                    case 88: // 88 = key X
                        Environment.Exit(0);
                        break;
                }

            }


        }
    }
}
