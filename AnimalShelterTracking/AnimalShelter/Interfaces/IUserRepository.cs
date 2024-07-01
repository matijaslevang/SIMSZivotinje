using AnimalShelter.Model.Users;
using System.Collections.Generic;

namespace AnimalShelter.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        void Update(int userId, User newUser);
        User Get(int userId);
        void Delete(int userId);
        List<User> GetAll();
        void SaveAll();
        void LoadAll();
    }
}
