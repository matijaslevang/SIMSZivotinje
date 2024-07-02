using AnimalShelter.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.Model.Requests
{
    public class TemporaryCareRequestService
    {
        private readonly IRepository<TemporaryCareRequest> _repository;
        private const string filePath = "..\\..\\Data\\TemporaryCareRequests.json";

        public TemporaryCareRequestService()
        {
            _repository = new JSONRepository<TemporaryCareRequest>(filePath);
        }

        public int GetHighestIdValue()
        {
            return _repository.GetAll().Max(v => v.Id);
        }

        public void Add(TemporaryCareRequest newTemporaryCareRequest)
        {
            _repository.Add(newTemporaryCareRequest);
        }

        public void Update(int requestId, TemporaryCareRequest newTemporaryCareRequest)
        {
            _repository.Update(requestId, newTemporaryCareRequest);
        }

        public TemporaryCareRequest Get(int requestId)
        {
            return _repository.Get(requestId);
        }

        public void Delete(int requestId)
        {
            _repository.Delete(requestId);
        }

        public List<TemporaryCareRequest> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
