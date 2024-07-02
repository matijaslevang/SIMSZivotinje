using AnimalShelter.Repository;
using System.Collections.Generic;

namespace AnimalShelter.Model.Votes
{
    public class VoteService
    {
        private readonly IRepository<Vote> _repository;
        private const string filePath = "..\\..\\Data\\Votes.json";

        public VoteService()
        {
            _repository = new JSONRepository<Vote>(filePath);
        }

        public void Add(Vote newVote)
        {
            _repository.Add(newVote);
        }

        public void Update(int voteId, Vote newVote)
        {
            _repository.Update(voteId, newVote);
        }

        public Vote Get(int voteId)
        {
            return _repository.Get(voteId);
        }

        public void Delete(int voteId)
        {
            _repository.Delete(voteId);
        }

        public List<Vote> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
