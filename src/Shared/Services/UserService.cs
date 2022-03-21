using Data.Entity;
using Core.Interfaces.Repository;

namespace Shared.Services
{
    public class UserService
    {
        private readonly IDataStore<User> userRepository;
        public UserService(IDataStore<User> userRepository)
        {
            this.userRepository = userRepository;
        }
        public void AddEntity(User entity)
        {
            try
            {
                userRepository.AddEntity(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                userRepository.Delete(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
               return userRepository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User GetById(int id)
        {
            try
            {
                return userRepository.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateEntity(User entity)
        {
            try
            {
                userRepository.UpdateEntity(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
