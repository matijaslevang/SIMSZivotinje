using AnimalShelter.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.Model.Pets
{
    public class BreedService
    {
        private readonly IRepository<Breed> _repository;
        private const string filePath = "..\\..\\Data\\Breeds.json";

        public BreedService()
        {
            _repository = new JSONRepository<Breed>(filePath);
        }

        public void Add(Breed newBreed)
        {
            _repository.Add(newBreed);
        }

        public void Update(int breedId, Breed newBreed)
        {
            _repository.Update(breedId, newBreed);
        }

        public Breed Get(int breedId)
        {
            return _repository.Get(breedId);
        }


        public void Delete(int breedId)
        {
            _repository.Delete(breedId);
        }

        public List<Breed> GetAll()
        {
            return _repository.GetAll();
        }
        public List<Breed> GetBySpeciesId(int speciesId)
        {
            return _repository.GetAll().Where(b => b.SpeciesId == speciesId).ToList();
        }
    }
}
