using Data.Entity;
using Data.Context;
using Core.Interfaces.Repository;


namespace Shared.Repository
{
    public class UserRepository: IDataStore<User>
    {
        private readonly FortuneDbContext _dbContext;
        public UserRepository(FortuneDbContext fortuneDbContext)
        {
            _dbContext = fortuneDbContext;
        }

        public void AddEntity(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();

        }

        public void Delete(int id)
        {
            var user = GetById(id);

            _dbContext.Users.Remove((User)user);
            _dbContext.SaveChanges();

        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public User GetById(int id)
        {
            var user = GetAll().FirstOrDefault(x => x.Id == id);

            return user ?? new User();
        }

        public void UpdateEntity(User entity)
        {
            _dbContext.Update<User>(entity);
            _dbContext.SaveChanges();
        }
    }
}
