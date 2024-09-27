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
                
                // Loops and writes out all posts
                i=0;
                foreach (Post post in posts.GetPosts())
                {
                    Console.WriteLine($"[{i}] {post.Author}: {post.Message}");
                    i++;
                }

                //Gets user inpur
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

            }


        }
    }
}
