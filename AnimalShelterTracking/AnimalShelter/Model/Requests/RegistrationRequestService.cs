using AnimalShelter.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.Model.Requests
{
    public class RegistrationRequestService
    {
        private readonly IRepository<RegistrationRequest> _repository;
        private const string filePath = "..\\..\\Data\\RegistrationRequests.json";

        public RegistrationRequestService()
        {
            _repository = new JSONRepository<RegistrationRequest>(filePath);
        }

        public int GetHighestIdValue()
        {
            return _repository.GetAll().Max(v => v.Id);
        }

        public void Add(RegistrationRequest newRegistrationRequest)
        {
            _repository.Add(newRegistrationRequest);
        }

        public void Update(int requestId, RegistrationRequest newRegistrationRequest)
        {
            _repository.Update(requestId, newRegistrationRequest);
        }

        public RegistrationRequest Get(int requestId)
        {
            return _repository.Get(requestId);
        }

        public void Delete(int requestId)
        {
            _repository.Delete(requestId);
        }

        public List<RegistrationRequest> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
