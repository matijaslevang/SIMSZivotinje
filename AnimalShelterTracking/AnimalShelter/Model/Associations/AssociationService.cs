using AnimalShelter.Repository;
using System.Collections.Generic;

namespace AnimalShelter.Model.Associations
{
    public class AssociationService
    {
        private readonly IRepository<Association> _repository;
        private const string filePath = "..../Data/Associations.json";

        public AssociationService()
        {
            _repository = new JSONRepository<Association>(filePath);
        }

        public void Add(Association newAssociation)
        {
            _repository.Add(newAssociation);
        }

        public void Update(int associationId, Association newAssociation)
        {
            _repository.Update(associationId, newAssociation);
        }

        public Association Get(int associationId)
        {
            return _repository.Get(associationId);
        }

        public void Delete(int associationId)
        {
            _repository.Delete(associationId);
        }

        public List<Association> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
