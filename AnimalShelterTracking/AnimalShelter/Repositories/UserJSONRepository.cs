using AnimalShelter.Interfaces;
using AnimalShelter.Model.Users;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace AnimalShelter.Repositories
{
    public class UserJSONRepository : IUserRepository
    {
        private readonly string filePath;
        private Dictionary<int, User> users;
        
        public UserJSONRepository(string filePath)
        {
            this.filePath = filePath;
            LoadAll();
        }

        private int GenerateId()
        {
            if (users.Keys != null)
            {
                return users.Keys.Max() + 1;
            }
            return 0;
        }

        public void Add(User user)
        {
            user.Id = GenerateId();
            users.Add(user.Id, user);
            SaveAll();
        }

        public void Delete(int userId)
        {
            if (users.ContainsKey(userId))
            {
                users.Remove(userId);
                SaveAll();
            }
        }

        public User Get(int userId)
        {
            return users[userId];
        }

        public List<User> GetAll()
        {
            return new List<User>(users.Values);
        }

        public void LoadAll()
        {
            string jsonString = File.ReadAllText(filePath);
            if (jsonString != null)
            {
                users = JsonSerializer.Deserialize<Dictionary<int, User>>(jsonString);
            }
            else
            {
                users = new Dictionary<int, User>();
            }
        }

        public void SaveAll()
        {
            string jsonString = JsonSerializer.Serialize(users);
            File.WriteAllText(filePath, jsonString);
        }

        public void Update(int userId, User newUser)
        {
            newUser.Id = userId;
            users[userId] = newUser;
            SaveAll();
        }
    }
}
