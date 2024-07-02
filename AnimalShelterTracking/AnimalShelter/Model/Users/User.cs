using AnimalShelter.Model.Enums;
using System;

namespace AnimalShelter.Model.Users
{
    public abstract class User
    {
        public int Id { get; set; }
        public Account Account { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string IdCardNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
}
