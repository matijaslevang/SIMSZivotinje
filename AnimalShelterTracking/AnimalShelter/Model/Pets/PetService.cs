using AnimalShelter.Repository;
using System.Collections.Generic;

namespace AnimalShelter.Model.Pets
{
    public class PetService
    {
        private readonly IRepository<Pet> _repository;
        private const string filePath = "..\\..\\Data\\Pets.json";

        public PetService()
        {
            _repository = new JSONRepository<Pet>(filePath);
        }

        public void Add(Pet newPet)
        {
            _repository.Add(newPet);
        }

        public void Update(int petId, Pet newPet)
        {
            _repository.Update(petId, newPet);
        }

        public Pet Get(int petId)
        {
            return _repository.Get(petId);
        }

        public void Delete(int petId)
        {
            _repository.Delete(petId);
        }

        public List<Pet> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
