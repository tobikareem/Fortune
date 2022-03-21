

namespace Core.Interfaces.Repository
{
    public interface IDataStore<T> where T : class
    {
        void AddEntity(T entity);

        void UpdateEntity(T entity);

        void Delete(int id);

        IEnumerable<T> GetAll();

        T GetById(int id);

        
    }
}
