using AnimalShelter.Model.Enums;
using AnimalShelter.Model.Utilities;
using System.Collections.Generic;

namespace AnimalShelter.Model.Pets
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public HealthStatus HealthStatus { get; set; }
        public string HealthDescription { get; set; }
        public int Age { get; set; }
        public bool IsAdopted { get; set; }
        public string Color { get; set; }
        public string Location { get; set; }
        public Species Species { get; set; }
        public Breed Breed { get; set; }
        public List<MultimediaContent> MultimediaContent { get; set; }

        public Pet() { }

        public Pet(string name, HealthStatus healthStatus, string healthDescription, int age, bool isAdopted, string color, string location, Species species, Breed breed, List<MultimediaContent> multimediaContent)
        {
            Name = name;
            HealthStatus = healthStatus;
            HealthDescription = healthDescription;
            Age = age;
            IsAdopted = isAdopted;
            Color = color;
            Location = location;
            Species = species;
            Breed = breed;
            MultimediaContent = multimediaContent;
        }

        public void AddMultimedia(MultimediaContent multimedia)
        {
            MultimediaContent.Add(multimedia);
        }

        public void RemoveMultimedia(int listIndex)
        {
            MultimediaContent.RemoveAt(listIndex);
        }
    }
}
