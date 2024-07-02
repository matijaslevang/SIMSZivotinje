using AnimalShelter.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.Model.Requests
{
    public class PostRequestService
    {
        private readonly IRepository<PostRequest> _repository;
        private const string filePath = "..\\..\\Data\\PostRequests.json";

        public PostRequestService()
        {
            _repository = new JSONRepository<PostRequest>(filePath);
        }

        public int GetHighestIdValue()
        {
            return _repository.GetAll().Max(v => v.Id);
        }

        public void Add(PostRequest newPostRequest)
        {
            _repository.Add(newPostRequest);
        }

        public void Update(int requestId, PostRequest newPostRequest)
        {
            _repository.Update(requestId, newPostRequest);
        }

        public PostRequest Get(int requestId)
        {
            return _repository.Get(requestId);
        }

        public void Delete(int requestId)
        {
            _repository.Delete(requestId);
        }

        public List<PostRequest> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
