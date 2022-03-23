using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces.Repository
{
    public interface IBaseStore<T> where T : class
    {
        void AddEntity(T entity);
        void UpdateEntity(T entity);
        IEnumerable<T> GetAll();

    }
}
