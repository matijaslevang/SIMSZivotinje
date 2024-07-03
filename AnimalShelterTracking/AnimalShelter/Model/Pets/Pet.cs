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
        public Gender Gender { get; set; }
        public AdoptionStatus AdoptionStatus { get; set; }
        public string Color { get; set; }
        public string Location { get; set; }
        public Species Species { get; set; }
        public Breed Breed { get; set; }
        public List<string> MultimediaContent { get; set; }

        public Pet() { }

        public Pet(string name, HealthStatus healthStatus, string healthDescription, int age, Gender gender, string color, string location, Species species, Breed breed, List<string> multimediaContent)
        {
            Name = name;
            HealthStatus = healthStatus;
            HealthDescription = healthDescription;
            Age = age;
            Gender = gender;
            Color = color;
            Location = location;
            Species = species;
            Breed = breed;
            MultimediaContent = multimediaContent;
            AdoptionStatus = AdoptionStatus.NOT_ADOPTED;
        }

        public void AddMultimedia(string multimedia)
        {
            MultimediaContent.Add(multimedia);
        }

        public void RemoveMultimedia(int listIndex)
        {
            MultimediaContent.RemoveAt(listIndex);
        }
    }
}
