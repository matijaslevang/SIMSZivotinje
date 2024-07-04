using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace AnimalShelter.Repository
{
    public class JSONRepository<T> : IRepository<T> where T : class
    {
        private readonly string filePath;
        private Dictionary<int, T> data;

        public JSONRepository(string filePath)
        {
            this.filePath = filePath;
            Deserialize();
        }
        private int GenerateId()
        {
            if (data.Keys.Count() != 0 )
            {
                return data.Keys.Max() + 1;
            }
            return 0;
        }
        public void Add(T entity)
        {
            Type type = typeof(T);
            PropertyInfo id = type.GetProperty("Id", typeof(int));
            id.SetValue(entity, GenerateId());
            data.Add((int)id.GetValue(entity), entity);
            Serialize();
        }

        public void Update(int entityId, T newEntity)
        {
            Type type = typeof(T);
            PropertyInfo id = type.GetProperty("Id", typeof(int));
            id.SetValue(newEntity, entityId);
            data[entityId] = newEntity;
            Serialize();
        }

        public void Delete(int entityId)
        {
            if (data.ContainsKey(entityId))
            {
                data.Remove(entityId);
                Serialize();
            }
        }

        public T Get(int entityId)
        {
            return data[entityId];
        }

        public List<T> GetAll()
        {
            return new List<T>(data.Values);
        }

        public void Deserialize()
        {
            string jsonString = File.ReadAllText(filePath);
            if (jsonString != null)
            {
                data = JsonSerializer.Deserialize<Dictionary<int, T>>(jsonString);
            }
            else
            {
                data = new Dictionary<int, T>();
            }
        }

        public void Serialize()
        {
            string jsonString = JsonSerializer.Serialize(data);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
