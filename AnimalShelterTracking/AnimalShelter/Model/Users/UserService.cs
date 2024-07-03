using AnimalShelter.Model.Enums;
using AnimalShelter.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.Model.Users
{
    public class UserService
    {
        private readonly IRepository<User> _repository;
        private const string adminsFilePath = "..\\..\\Data\\Admins.json";
        private const string membersFilePath = "..\\..\\Data\\Members.json";
        private const string volunteersFilePath = "..\\..\\Data\\Volunteers.json";

        public UserService()
        {
            _repository = new UsersJSONRepository(adminsFilePath, membersFilePath, volunteersFilePath);
        }

        private bool IsEmailTaken(string email)
        {
            return _repository.GetAll().Any(v => v.Account.Email == email);
        }

        public bool Add(User newUser)
        {
            if (IsEmailTaken(newUser.Account.Email))
                return false;
            _repository.Add(newUser);
            return true;
        }

        public void Update(int userId, User newUser)
        {
            _repository.Update(userId, newUser);
        }

        public User Get(int userId)
        {
            return _repository.Get(userId);
        }

        public void Delete(int userId)
        {
            _repository.Delete(userId);
        }

        public List<User> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Member> GetAllMembers()
        {
            List<User> members = _repository.GetAll().FindAll(v => v.Account.Role == Role.MEMBER);
            return members.ConvertAll(v => (Member) v);
        }

        public List<Volunteer> GetAllVolunteers() 
        {
            List<User> volunteers = _repository.GetAll().FindAll(v => v.Account.Role == Role.VOLUNTEER);
            return volunteers.ConvertAll(v => (Volunteer) v);
        }

        public User Login(string email, string password)
        {
            return _repository.GetAll().Find(v => v.Account.Email == email && v.Account.Password == password);
        }

        public int GenerateId()
        {
            return _repository.GetAll().Count + 1;
        }

        public bool CheckExistingEmail(string email)
        {
            var users = _repository.GetAll();
            foreach (var kv in users)
            {
                if (kv.Account.Email == email) return true;
            }

            return false;
        }
    }
}
