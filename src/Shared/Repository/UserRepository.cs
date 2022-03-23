using Data.Context;
using Shared.Interfaces.Repository;
using Microsoft.AspNetCore.Identity;

namespace Shared.Repository
{
    public class UserRepository: IStringIdStore<IdentityUser>
    {
        private readonly FortuneDbContext _dbContext;
        public UserRepository(FortuneDbContext fortuneDbContext)
        {
            _dbContext = fortuneDbContext;
        }

        public void AddEntity(IdentityUser entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var user = GetById(id);

            if(user is default(IdentityUser))
            {
                return;
            }
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public IEnumerable<IdentityUser> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public IdentityUser GetById(string id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            return user ?? new IdentityUser();
        }

        public void UpdateEntity(IdentityUser entity){
            _dbContext.Update<IdentityUser>(entity);
            _dbContext.SaveChanges();
        }
    }
}
