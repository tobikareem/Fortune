

namespace Shared.Interfaces.Repository
{
    public interface IDataStore<T> : IBaseStore<T> where T : class
    {
        void Delete(int id);

        T GetById(int id);

        IEnumerable<T> GetByUserId(string userId);
    }
}
