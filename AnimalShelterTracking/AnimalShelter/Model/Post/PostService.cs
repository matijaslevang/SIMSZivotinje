using AnimalShelter.Repository;
using System.Collections.Generic;

namespace AnimalShelter.Model.Post
{
    public class PostService
    {
        private readonly IRepository<Post> _repository;
        private const string filePath = "..\\..\\Data\\Posts.json";

        public PostService()
        {
            _repository = new JSONRepository<Post>(filePath);
        }

        public void Add(Post newPost)
        {
            _repository.Add(newPost);
        }

        public void Update(int postId, Post newPost)
        {
            _repository.Update(postId, newPost);
        }

        public Post Get(int postId)
        {
            return _repository.Get(postId);
        }

        public void Delete(int postId)
        {
            _repository.Delete(postId);
        }

        public List<Post> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
