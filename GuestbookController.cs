using System.Text.Json;


namespace Guestbook
{
    public class GuestbookController
    {
        private string filename = @"guestbook.json"; // Stores path to file
        private List<Post> _posts = []; // Variable to store the list of posts in

        // Constructor - Checks if file exists and is not empty, else creates a new file containing empty brackets
        public GuestbookController()
        {
            try
            {
                if (File.Exists(filename))
                {
                    string jsonString = File.ReadAllText(filename); // Reads file
                    if (String.IsNullOrEmpty(jsonString)){
                        File.WriteAllText(filename, "[]"); // Adds brackets
                    }
                    else
                    {
                        _posts = JsonSerializer.Deserialize<List<Post>>(jsonString) ?? [];
                    }
                }
                else
                {
                    File.WriteAllText(filename, "[]"); // Creates a file and adds brackets
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Något gick fel: {e}");
            }

        }

        // Adds a new post
        public Post AddPost(string author, string message){
            // Creates an instance of Post and adds values to properties
            Post post = new()
            {
                Author = author,
                Message = message
            };

            _posts.Add(post); // Adds post to list
            WriteToFile();
            return post;
        }

        // Removes post from list using index
        public int RemovePost(int index){
            _posts.RemoveAt(index);
            WriteToFile();
            return index;
        }

        // Returns the list of _posts
        public List<Post> GetPosts()
        {
            return _posts;
        }

        // Serializing to JSON and writes data to file
        private void WriteToFile()
        {
            var jsonString = JsonSerializer.Serialize(_posts);
            File.WriteAllText(filename, jsonString);
        }
    }
}