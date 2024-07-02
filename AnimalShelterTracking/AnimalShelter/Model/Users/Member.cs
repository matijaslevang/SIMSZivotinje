using AnimalShelter.Model.Enums;
using System;
using System.Collections.Generic;

namespace AnimalShelter.Model.Users
{
    public class Member : User
    {
        public bool IsBlacklisted { get; set; }
        public List<int> AdoptedPets { get; set; }

        public Member() { }

        public Member(int id, Account account, string name, string surname, string phoneNumber, string idCardNumber, DateTime birthDate, Gender gender, DateTime dateOfJoining, bool isBlacklisted, List<int> adoptedPets)
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

        public Member(Account account, string name, string surname, string phoneNumber, string idCardNumber, DateTime birthDate, Gender gender)
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

        public void AddAdoptedPet(int petId)
        {
            AdoptedPets.Add(petId);
        }

        public void RemoveAdoptedPet(int petId)
        {
            AdoptedPets.Remove(petId);
        }
    }
}
