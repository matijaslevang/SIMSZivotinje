using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace AnimalShelter.Model.Post
{
    public class PostRepo : IPostRepo
    {
        private const string FILE_PATH = "..\\..\\Data\\Posts.json";
        public Dictionary<int, Post> PostMap { get; set; }
        public int Id { get; set; }
        public PostRepo() { PostMap = new Dictionary<int, Post>(); }
        private int SetId()
        {
            if (PostMap.Count != 0)
            {
                int maxKey = PostMap.Keys.Max();
                Id = maxKey + 1;
                return Id;
            }
            else
            {
                Id = 0;
                return 0;
            }
        }
        public void Add(Post post)
        {
            post.Id = SetId();
            PostMap.Add(post.Id, post);
            Serialize();
        }

        public Post Get(int id)
        {
            return PostMap[id];
        }

        public void Update(Post post, Post updatedPost)
        {
            updatedPost.Id = post.Id;
            PostMap[post.Id] = updatedPost;
            Serialize();
        }
        public void Delete(Post post)
        {
            PostMap.Remove(post.Id);
            Serialize();
            return;
        }

        public List<Post> GetAll()
        {
            return PostMap.Values.ToList();
        }
        public void Serialize()
        {
            string jsonString = JsonSerializer.Serialize(PostMap);
            File.WriteAllText(FILE_PATH, jsonString);
        }

        public void Deserialize()
        {
            string jsonString = File.ReadAllText(FILE_PATH);
            if (jsonString != "")
            {
                PostMap = JsonSerializer.Deserialize<Dictionary<int, Post>>(jsonString);
            }
        }

    }
}
