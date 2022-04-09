using Shared.Interfaces.Repository;
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
            _dbContext.Categories.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = GetById(id);

            _dbContext.Categories.Remove((Category)category);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            return _dbContext.Categories.ToList();
        }

        public Category GetById(int id)
        {
            var category = GetAll().FirstOrDefault(x => x.Id == id);

            return category ?? new Category();
        }

        public IEnumerable<Category> GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(Category entity)
        {
            _dbContext.Update<Category>(entity);
            _dbContext.SaveChanges();
        }
    }
}
