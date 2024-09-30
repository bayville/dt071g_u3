using System.Text.Json;


namespace Guestbook
{
    public class GuestbookController
    {
        private string filename = @"guestbook.json"; // Stores path to file
        private List<Post> posts = []; // F

        // Constructor - Checks if file exists and is not empty, else creates a new file containing empty brackets
        public GuestbookController()
        {
            if (File.Exists(filename))
            {
                string jsonString = File.ReadAllText(filename); // Reads file
                if (String.IsNullOrEmpty(jsonString)){
                    File.WriteAllText(filename, "[]"); // Adds brackets
                }
                else
                {
                    posts = JsonSerializer.Deserialize<List<Post>>(jsonString)!;
                }
            }
            else
            {
                File.WriteAllText(filename, "[]"); // Creates a file and adds brackets
            }
        }

        // Adds a new post
        public void AddPost(string author, string message){
            // Creates an instance of Post and adds values to properties
            Post post = new()
            {
                Author = author,
                Message = message
            };

            posts.Add(post); // Adds post to list
            WriteToFile();
        }

        public void RemovePost(int index){
            posts.RemoveAt(index);
        }

        // Returns the list of posts
        public List<Post> GetPosts()
        {
            return posts;
        }

        // Serializing to JSON and writes data to file
        private void WriteToFile()
        {
            var jsonString = JsonSerializer.Serialize(posts);
            File.WriteAllText(filename, jsonString);
        }
    }
}