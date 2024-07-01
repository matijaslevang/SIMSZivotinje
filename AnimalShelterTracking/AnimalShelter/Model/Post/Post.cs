using AnimalShelter.Model.Enums;
using AnimalShelter.Model.Users;
using System;

namespace AnimalShelter.Model.Post
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime postDate { get; set; }
        public Member Author { get; set; }
        public PostStatus Status { get; set; }
        public int LikesNum { get; set; }
        public Post() { }
        public Post(int id, Member author)
        {
            Id = id;
            Author = author;

            postDate = DateTime.Now;
            Status = PostStatus.PENDING_APPROVAL;
            LikesNum = 0;
        }
    }
}
