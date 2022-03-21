using Core.Interfaces.Repository;
using Data.Entity;
using Data.Context;

namespace Shared.Repository
{
    public class CategoryRepository : IDataStore<Category>
    {

        private readonly FortuneDbContext _dbContext;
        public CategoryRepository(FortuneDbContext fortuneDbContext)
        {
            _dbContext = fortuneDbContext;
        }

        public void AddEntity(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            return _dbContext.Categories.ToList();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
