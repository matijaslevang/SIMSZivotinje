using AnimalShelter.Model.Enums;
using System;
using System.Collections.Generic;

namespace AnimalShelter.Model.Users
{
    public class Volunteer : Member
    {
        public Volunteer(int id, Account account, string name, string surname, string phoneNumber, string idCardNumber, DateTime birthDate, Gender gender, DateTime dateOfJoining, bool isBlacklisted, List<int> adoptedPets)
        {
            Id = id;
            Account = account;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            IdCardNumber = idCardNumber;
            BirthDate = birthDate;
            Gender = gender;
            DateOfJoining = dateOfJoining;
            IsBlacklisted = isBlacklisted;
            AdoptedPets = adoptedPets;
        }

        public Volunteer(Account account, string name, string surname, string phoneNumber, string idCardNumber, DateTime birthDate, Gender gender)
        {
            Account = account;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            IdCardNumber = idCardNumber;
            BirthDate = birthDate;
            Gender = gender;
            DateOfJoining = DateTime.Now;
            IsBlacklisted = false;
            AdoptedPets = new List<int>();
        }
    }
}
