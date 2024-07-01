using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Model.Post
{
    public interface IPostService
    {
        void Add(Post post);
        Post Get(int id);
        void Update(Post post, Post updatedPost);
        void Delete(Post post);
        List<Post> GetAll();
    }
}
