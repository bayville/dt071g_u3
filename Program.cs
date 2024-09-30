
namespace Guestbook
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GuestbookController posts = new(); // Creates an instance of of GuestbookController
            int i = 0; // Declares and int used in loop

            while (true)
            {   
                Console.Clear(); // Clears console
                 
                Console.WriteLine("1. Radera inlägg");
                Console.WriteLine("2. Skriv inlägg");
                Console.WriteLine("X. Avsluta\n");



                // Loops and writes out all posts
                i=0;
                foreach (Post post in posts.GetPosts())
                {
                    Console.WriteLine($"[{i}] {post.Author}: {post.Message}");
                    i++;
                }

                Console.WriteLine("Ange alternativ: ");
                int input = (int) Console.ReadKey(true).Key;

                switch (input)
                {
                    case '1':
                        // Gets user input
                        Console.WriteLine(input);
                        Console.Write("Ange Namn: ");
                        string? author = Console.ReadLine();
                        Console.Write("Ange Meddelande: ");
                        string? message = Console.ReadLine();

                        // Checks if string is empty
                        if (!String.IsNullOrEmpty(author) && !String.IsNullOrEmpty(message))
                        {
                            posts.AddPost(author, message);
                        }
                        else
                        {
                            
                        }
                        break;
                    case '2':
                        Console.WriteLine(input);
                        Console.Write("Ange nummer för inlägg att ta bort: ");
                        string? rm = Console.ReadLine();
                        int index = Convert.ToInt32(rm);
                        posts.RemovePost(index);
                        break;
                    case 88:
                        Console.WriteLine(input);
                        Environment.Exit(0);
                        break;
                }

          




            }


        }
    }
}
