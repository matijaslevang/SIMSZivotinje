using AnimalShelter.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.Model.Requests
{
    public class AdoptionRequestService
    {
        private readonly IRepository<AdoptionRequest> _repository;
        private const string filePath = "..\\..\\Data\\AdoptionRequests.json";

        public int GetHighestIdValue()
        {
            return _repository.GetAll().Max(v => v.Id);
        }

        public AdoptionRequestService()
        {
            _repository = new JSONRepository<AdoptionRequest>(filePath);
        }

        public void Add(AdoptionRequest newAdoptionRequest)
        {
            _repository.Add(newAdoptionRequest);
        }

        public void Update(int requestId, AdoptionRequest newAdoptionRequest)
        {
            _repository.Update(requestId, newAdoptionRequest);
        }

        public AdoptionRequest Get(int requestId)
        {
            return _repository.Get(requestId);
        }

        public void Delete(int requestId)
        {
            _repository.Delete(requestId);
        }

        public List<AdoptionRequest> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
