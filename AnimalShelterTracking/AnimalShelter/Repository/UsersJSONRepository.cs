using AnimalShelter.Model.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Markup;

namespace AnimalShelter.Repository
{
    public class UsersJSONRepository : IRepository<User>
    {
        private readonly string _adminsfilePath;
        private readonly string _membersfilePath;
        private readonly string _volunteersfilePath;

        private Dictionary<int, Administrator> admins;
        private Dictionary<int, Member> members;
        private Dictionary<int, Volunteer> volunteers;
        public UsersJSONRepository(string adminsFilePath, string membersFilePath, string volunteersFilePath)
        {
            _adminsfilePath = adminsFilePath;
            _membersfilePath = membersFilePath;
            _volunteersfilePath = volunteersFilePath;
            Deserialize();
        }
        private int GenerateId()
        {
            int maxAdminId = 0;
            int maxMemberId = 0;
            int maxVolunteerId = 0;
            if (admins.Keys.Count != 0)
            {
                maxAdminId = admins.Keys.Max() + 1;
            }
            if (members.Keys.Count != 0)
            {
                maxMemberId = members.Keys.Max() + 1;
            }
            if (volunteers.Keys.Count != 0)
            {
                maxVolunteerId = volunteers.Keys.Max() + 1;
            }
            List<int> maxIds = new List<int> { maxAdminId, maxMemberId, maxVolunteerId };
            return maxIds.Max();
        }

        public void Add(User entity)
        {
            entity.Id = GenerateId();
            switch (entity)
            {
                case Volunteer volunteer:
                    volunteers.Add(volunteer.Id, volunteer);
                    break;
                case Member member:
                    members.Add(member.Id, member);
                    break;
                case Administrator administrator:
                    admins.Add(administrator.Id, administrator);
                    break;
            }
            Serialize();
        }

        public void Delete(int entityId)
        {
            if (members.ContainsKey(entityId))
            {
                members.Remove(entityId);
                Serialize();
            }
            else if (volunteers.ContainsKey(entityId))
            {
                volunteers.Remove(entityId);
                Serialize();
            }
            else if (admins.ContainsKey(entityId))
            {
                admins.Remove(entityId);
                Serialize();
            }
        }

        public void Deserialize()
        {
            string adminString = File.ReadAllText(_adminsfilePath);
            if (adminString != null)
            {
                admins = JsonSerializer.Deserialize<Dictionary<int, Administrator>>(adminString);
            }
            else
            {
                admins = new Dictionary<int, Administrator>();
            }
            string memberString = File.ReadAllText(_membersfilePath);
            if (memberString != null)
            {
                members = JsonSerializer.Deserialize<Dictionary<int, Member>>(memberString);
            }
            else
            {
                members = new Dictionary<int, Member>();
            }
            string volunteerString = File.ReadAllText(_volunteersfilePath);
            if (volunteerString != null)
            {
                volunteers = JsonSerializer.Deserialize<Dictionary<int, Volunteer>>(volunteerString);
            }
            else
            {
                volunteers = new Dictionary<int, Volunteer>();
            }
        }

        public User Get(int entityId)
        {
            if (members.ContainsKey(entityId))
            {
                return members[entityId];
            }
            else if (volunteers.ContainsKey(entityId))
            {
                return volunteers[entityId];
            }
            else if (admins.ContainsKey(entityId))
            {
                return admins[entityId];
            }
            return null;
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            users.AddRange(members.Values);
            users.AddRange(volunteers.Values);
            users.AddRange(admins.Values);
            return users;
        }
        public void Serialize()
        {
            string adminString = JsonSerializer.Serialize(admins);
            File.WriteAllText(_adminsfilePath, adminString);
            string memberString = JsonSerializer.Serialize(members);
            File.WriteAllText(_membersfilePath, memberString);
            string volunteerString = JsonSerializer.Serialize(volunteers);
            File.WriteAllText(_volunteersfilePath, volunteerString);
        }

        public void Update(int entityId, User newEntity)
        {
            newEntity.Id = entityId;
            if (members.ContainsKey(entityId))
            {
                members[entityId] = (Member)newEntity;
            }
            else if (volunteers.ContainsKey(entityId))
            {
                volunteers[entityId] = (Volunteer)newEntity;
            }
            else if (admins.ContainsKey(entityId))
            {
                admins[entityId] = (Administrator)newEntity;
            }
        }
    }
}
