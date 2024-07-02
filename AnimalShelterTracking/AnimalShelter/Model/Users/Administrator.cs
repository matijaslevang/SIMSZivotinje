using AnimalShelter.Model.Enums;
using System;

namespace AnimalShelter.Model.Users
{
    public class Administrator : User
    {
        public Administrator(int id, Account account, string name, string surname, string phoneNumber, string idCardNumber, DateTime birthDate, Gender gender, DateTime dateOfJoining, bool isBlacklisted)
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
        }

        public Administrator(Account account, string name, string surname, string phoneNumber, string idCardNumber, DateTime birthDate, Gender gender)
        {
            Account = account;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            IdCardNumber = idCardNumber;
            BirthDate = birthDate;
            Gender = gender;
            DateOfJoining = DateTime.Now;
        }
    }
}
