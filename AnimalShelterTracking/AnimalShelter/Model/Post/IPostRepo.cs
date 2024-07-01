using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Model.Post
{
    public interface IPostRepo
    {
        void Add(Post course);
        Post Get(int id);
        void Update(Post course, Post updatedCourse);
        void Delete(Post course, bool isDean);
        List<Post> GetAll();
        void Serialize();
        void Deserialize();
    }
}
