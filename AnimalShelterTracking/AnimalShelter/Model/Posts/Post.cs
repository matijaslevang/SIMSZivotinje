using AnimalShelter.Model.Enums;
using AnimalShelter.Model.Users;
using AnimalShelter.Model.Pets;
using System;

namespace AnimalShelter.Model.Posts
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime postDate { get; set; }
        public Member Author { get; set; }
        public PostStatus Status { get; set; }
        public int LikesNum { get; set; }
        public Pet Pet { get; set; }
        public Post() { }
        public Post(int id, Member author, Pet pet)
        {
            Id = id;
            Author = author;
            Pet = pet;
            postDate = DateTime.Now;
            Status = PostStatus.PENDING_APPROVAL;
            LikesNum = 0;
        }
    }
}
