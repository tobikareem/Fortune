using Data.Context;
using Data.Entity;
using Shared.Interfaces.Repository;

namespace Shared.Repository
{
    public class SuggestionRepository: IBaseStore<Suggestions>
    {
        private readonly FortuneDbContext _dbContext;
        public SuggestionRepository(FortuneDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void AddEntity(Suggestions entity)
        {
            _dbContext.Suggestions.Add(entity);
            _dbContext.SaveChanges();
        }

        public void UpdateEntity(Suggestions entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Suggestions> GetAll()
        {
            return _dbContext.Suggestions.ToList();
        }
    }
}
