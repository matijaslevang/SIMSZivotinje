using System;

namespace AnimalShelter.Model.Posts
{
    public class Rating : ICommentable
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int RaterId { get; set; }
        public DateTime DatePosted { get; set; }
        public int Grade { get; set; }
        public string Comment { get; set; }
        public bool IsRating { get; set; }

        public Rating() { }

        public Rating(int id, int postId, int raterId, DateTime datePosted, int grade, string comment, bool isRating)
        {
            Id = id;
            PostId = postId;
            RaterId = raterId;
            DatePosted = datePosted;
            Grade = grade;
            Comment = comment;
            IsRating = isRating;
        }

        public Rating(int postId, int raterId, int grade, string comment)
        {
            PostId = postId;
            RaterId = raterId;
            Grade = grade;
            Comment = comment;
            DatePosted = DateTime.Now;
            IsRating = true;
        }
    }
}
