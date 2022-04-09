using Shared.Interfaces.Repository;
using Data.Context;
using Data.Entity;

namespace Shared.Repository
{
    public class CommentRepository : IDataStore<Comment>
    {
        private readonly FortuneDbContext _dbContext;

        public CommentRepository(FortuneDbContext fortuneDbContext)
        {
            _dbContext = fortuneDbContext;
        }

        public void AddEntity(Comment entity)
        {
            _dbContext.Comments.Add (entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var comment = GetById(id);

            _dbContext.Comments.Remove((Comment) comment);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Comment> GetAll()
        {
            return _dbContext.Comments.ToList();
        }

        public Comment GetById(int id)
        {
            var comment = GetAll().FirstOrDefault(x => x.Id == id);

            return comment ?? new Comment();
        }

        public IEnumerable<Comment> GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(Comment entity)
        {
            _dbContext.Update<Comment> (entity);
            _dbContext.SaveChanges();
        }
    }
}
