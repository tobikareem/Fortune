using Data.Entity;
using Core.Interfaces.Repository;

namespace Shared.Services
{
    public class CommentService
    {
        private readonly IDataStore<Comment> repository;

        public CommentService(IDataStore<Comment> repository)
        {
            this.repository = repository;
        }
        public void AddEntity(Comment entity)
        {
            try
            {
                repository.AddEntity(entity);
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
                repository.Delete(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Comment> GetAll()
        {
            try
            {
                return repository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Comment GetById(int id)
        {
            try
            {
                return repository.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateEntity(Comment entity)
        {
            try
            {
                repository.UpdateEntity(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
