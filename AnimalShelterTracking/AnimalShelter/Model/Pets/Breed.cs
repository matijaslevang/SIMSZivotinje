﻿namespace AnimalShelter.Model.Pets
{
    public class Breed
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        public string Name { get; set; }

        public Breed() { }

        public Breed(int speciesId, string name)
        {
            SpeciesId = speciesId;
            Name = name;
        }
        public Breed(string name)
        {
            Name = name;
        }
    }
    public class BreedWrapper
    {
        public Breed Breed { get; set; }
        public string Name => Breed.Name;

        public BreedWrapper(Breed breed)
        {
            Breed = breed;
        }
    }

}
