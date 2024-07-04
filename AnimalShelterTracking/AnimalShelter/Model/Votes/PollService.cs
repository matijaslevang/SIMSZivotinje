using AnimalShelter.Repository;
using System.Collections.Generic;

namespace AnimalShelter.Model.Votes
{
    public class PollService
    {
        private readonly IRepository<Poll> _repository;
        private const string filePath = "..\\..\\Data\\Polls.json";

        public PollService()
        {
            _repository = new JSONRepository<Poll>(filePath);
        }

        public void Add(Poll newVote)
        {
            _repository.Add(newVote);
        }

        public void Update(int voteId, Poll newVote)
        {
            _repository.Update(voteId, newVote);
        }

        public Poll Get(int voteId)
        {
            return _repository.Get(voteId);
        }

        public void Delete(int voteId)
        {
            _repository.Delete(voteId);
        }

        public List<Poll> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
