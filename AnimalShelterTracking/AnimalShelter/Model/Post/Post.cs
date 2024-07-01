using AnimalShelter.Model.Enums;
using System;

namespace AnimalShelter.Model.Post
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime postDate { get; set; }
        public Member.Member Author { get; set; }
        public PostStatus Status { get; set; }
        public int LikesNum { get; set; }
        public Post() { }
        public Post(int id, Member.Member author)
        {
            Id = id;
            Author = author;

            postDate = DateTime.Now;
            Status = PostStatus.PENDING_APPROVAL;
            LikesNum = 0;
        }
    }
}
