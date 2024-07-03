using AnimalShelter.Repository;
using System.Collections.Generic;

namespace AnimalShelter.Model.Posts
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

        public List<ICommentable> GetAllCommentsAndRatingsForPostId(int postId) 
        {
            List<ICommentable> commentables = new List<ICommentable>();

            commentables.AddRange(new CommentService().GetAllForPostId(postId));
            commentables.AddRange(new RatingService().GetAllForPostId(postId));

            return commentables;
        }

        public void ApprovePost(Post post)
        {
            post.Status = Enums.PostStatus.APPROVED;
            Update(post.Id, post);
        }

        public void DenyPost(Post post)
        {
            post.Status = Enums.PostStatus.DENIED;
            Update(post.Id, post);
        }

        public void DeletePost(Post post)
        {
            post.Status = Enums.PostStatus.DELETED;
            Update(post.Id, post);
        }
    }
}
