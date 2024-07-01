namespace AnimalShelter.Model.Users
{
    public abstract class User
    {
        public int Id { get; set; }
        public Account Account { get; set; }

    }
}
