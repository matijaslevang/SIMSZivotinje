namespace AnimalShelter.Model.Pets
{
    public class Species
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public Species() { }
        
        public Species(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
    public class SpeciesWrapper
    {
        public Species Species { get; set; }
        public string Name => Species.Name;

        public SpeciesWrapper(Species species)
        {
            Species = species;
        }
    }
}
