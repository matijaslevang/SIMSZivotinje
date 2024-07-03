using AnimalShelter.Model.Enums;
using AnimalShelter.Model.Users;
using AnimalShelter.Model.Pets;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.Model.Posts
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime PostDate { get; set; }
        public Member Author { get; set; }
        public PostStatus Status { get; set; }
        public List<int> LikedBy { get; set; }
        public Pet Pet { get; set; }
        public Post() { }
        public Post(int id, Member author, Pet pet)
        {
            Id = id;
            Author = author;
            Pet = pet;
            PostDate = DateTime.Now;
            Status = PostStatus.PENDING_APPROVAL;
            LikedBy = new List<int>();
        }
        public Post(Member author, Pet pet)
        {
            Author = author;
            Pet = pet;
            PostDate = DateTime.Now;
            Status = PostStatus.PENDING_APPROVAL;
            LikedBy = new List<int>();
        }

        public Post(Volunteer author, Pet pet)
        {
            Author = author;
            Pet = pet;
            PostDate = DateTime.Now;
            Status = PostStatus.POSTED;
            LikedBy = new List<int>();
        }

        public void AddLike(int userId)
        {
            if (!IsLikedByUser(userId))
            {
                LikedBy.Add(userId);
            }
        }

        public void RemoveLike(int userId)
        {
            if (IsLikedByUser(userId))
            {
                LikedBy.Remove(userId);
            }
        }

        public bool IsLikedByUser(int userId)
        {
            return LikedBy.Any(v => v == userId);
        }

    }
}
