using Data.Entity;

using Shared.Interfaces.Repository;

namespace Shared.Services
{
    public class PostService
    {
        private readonly IDataStore<Post> postRepository;
        public PostService(IDataStore<Post> postRepository)
        {
            this.postRepository = postRepository;
        }

        public void AddEntity(Post entity)
        {
            try
            {
                postRepository.AddEntity(entity);
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
                //postRepository.Delete(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Post> GetAll()
        {
            try
            {
                return postRepository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Post GetById(int id)
        {
            try
            {
                return new Post();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateEntity(Post entity)
        {
            try
            {
                postRepository.UpdateEntity(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
