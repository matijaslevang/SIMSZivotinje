using AnimalShelter.Model.Pets;
using AnimalShelter.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Model.Posts
{
    public class RatingService
    {
        private readonly IRepository<Rating> _repository;
        private const string filePath = "..\\..\\Data\\Ratings.json";

        public RatingService()
        {
            _repository = new JSONRepository<Rating>(filePath);
        }

        public void Add(Rating newRating)
        {
            _repository.Add(newRating);
        }

        public void Update(int ratingId, Rating newRating)
        {
            _repository.Update(ratingId, newRating);
        }

        public Rating Get(int ratingId)
        {
            return _repository.Get(ratingId);
        }

        public void Delete(int ratingId)
        {
            _repository.Delete(ratingId);
        }

        public List<Rating> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Rating> GetAllForPostId(int postId)
        {
            return _repository.GetAll().FindAll(v => v.PostId == postId);
        }
    }
}
