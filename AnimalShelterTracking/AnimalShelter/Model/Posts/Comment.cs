using System;
using AnimalShelter.Model.Users;

namespace AnimalShelter.Model.Posts
{
    public class Comment : ICommentable
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public DateTime DatePosted { get; set; }
        public Member Commenter { get; set; }
        public string Content { get; set; }
        public bool IsRating { get; set; }

        public Comment() { }

        public Comment(int id, int postId, DateTime datePosted, Member commenter, string content, bool isRating)
        {
            Id = id;
            PostId = postId;
            DatePosted = datePosted;
            Commenter = commenter;
            Content = content;
            IsRating = isRating;
        }

        public Comment(int postId, Member commenter, string content)
        {
            PostId = postId;
            Commenter = commenter;
            Content = content;
            DatePosted = DateTime.Now;
            IsRating = false;
        }
    }
}
