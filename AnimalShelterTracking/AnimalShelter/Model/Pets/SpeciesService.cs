using AnimalShelter.Repository;
using System.Collections.Generic;

namespace AnimalShelter.Model.Pets
{
    public class SpeciesService
    {
        private readonly IRepository<Species> _repository;
        private const string filePath = "..../Data/Species.json";

        public SpeciesService()
        {
            _repository = new JSONRepository<Species>(filePath);
        }

        public void Add(Species newSpecies)
        {
            _repository.Add(newSpecies);
        }

        public void Update(int speciesId, Species newSpecies)
        {
            _repository.Update(speciesId, newSpecies);
        }

        public Species Get(int speciesId)
        {
            return _repository.Get(speciesId);
        }

        public void Delete(int speciesId)
        {
            _repository.Delete(speciesId);
        }

        public List<Species> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
