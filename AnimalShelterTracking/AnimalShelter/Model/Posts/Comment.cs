using System;

namespace AnimalShelter.Model.Posts
{
    public class Comment : ICommentable
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public DateTime DatePosted { get; set; }
        public int CommenterId { get; set; }
        public string Content { get; set; }
        public bool IsRating { get; set; }

        public Comment() { }

        public Comment(int id, int postId, DateTime datePosted, int commenterId, string content, bool isRating)
        {
            Id = id;
            PostId = postId;
            DatePosted = datePosted;
            CommenterId = commenterId;
            Content = content;
            IsRating = isRating;
        }

        public Comment(int postId, int commenterId, string content)
        {
            PostId = postId;
            CommenterId = commenterId;
            Content = content;
            DatePosted = DateTime.Now;
            IsRating = false;
        }
    }
}
