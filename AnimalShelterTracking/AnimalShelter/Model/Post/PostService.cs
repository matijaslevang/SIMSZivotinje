using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Model.Post
{
    public class PostService : IPostService
    {

        private readonly IPostRepo _postRepo;
        public PostService(IPostRepo postRepo)
        {
            _postRepo = postRepo;
        }

        public void Add(Post post)
        {
            _postRepo.Add(post);
        }

        public void Delete(Post post)
        {
            _postRepo.Delete(post);
        }

        public Post Get(int id)
        {
            return _postRepo.Get(id);
        }

        public List<Post> GetAll()
        {
            return _postRepo.GetAll();
        }

        public void Update(Post post, Post updatedPost)
        {
            _postRepo.Update(post, updatedPost);
        }
    }
}
