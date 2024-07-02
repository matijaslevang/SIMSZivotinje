using AnimalShelter.Model.Requests;
using AnimalShelter.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Model.Requests
{
    public class RequestService
    {
        private readonly IRepository<Request> _repository;
        private const string filePath = "..\\..\\Data\\Requests.json";

        public RequestService()
        {
            _repository = new JSONRepository<Request>(filePath);
        }

        public void Add(Request newRequest)
        {
            _repository.Add(newRequest);
        }

        public void Update(int requestId, Request newRequest)
        {
            _repository.Update(requestId, newRequest);
        }

        public Request Get(int requestId)
        {
            return _repository.Get(requestId);
        }

        public void Delete(int requestId)
        {
            _repository.Delete(requestId);
        }

        public List<Request> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
