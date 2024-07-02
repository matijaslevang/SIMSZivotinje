using AnimalShelter.Repository;
using System.Collections.Generic;

namespace AnimalShelter.Model.Posts
{
    public class CommentService
    {
        private readonly IRepository<Comment> _repository;
        private const string filePath = "..\\..\\Data\\Comments.json";

        public CommentService()
        {
            _repository = new JSONRepository<Comment>(filePath);
        }

        public void Add(Comment newComment)
        {
            _repository.Add(newComment);
        }

        public void Update(int commentId, Comment newComment)
        {
            _repository.Update(commentId, newComment);
        }

        public Comment Get(int commentId)
        {
            return _repository.Get(commentId);
        }

        public void Delete(int commentId)
        {
            _repository.Delete(commentId);
        }

        public List<Comment> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Comment> GetAllForPostId(int postId)
        {
            return _repository.GetAll().FindAll(v => v.PostId == postId);
        }
    }
}
