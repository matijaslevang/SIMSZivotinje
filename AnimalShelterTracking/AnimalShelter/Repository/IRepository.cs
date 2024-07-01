using System.Collections.Generic;

namespace AnimalShelter.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(int entityId, T newEntity);
        T Get(int entityId);
        void Delete(int entityId);
        List<T> GetAll();
        void Serialize();
        void Deserialize();
    }
}
