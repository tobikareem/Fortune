
namespace Shared.Interfaces.Repository
{
    public interface IStringIdStore<T> : IBaseStore<T> where T : class
    {
        void Delete(string id);
        T GetById(string id);

    }
}
