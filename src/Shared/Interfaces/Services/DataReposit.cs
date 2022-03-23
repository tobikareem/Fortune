namespace Shared.Interfaces.Services
{
    public class DataReposit
    {
        private readonly DataContext _context;
        public DataReposit(DataContext dataContext)
        {
            _context = dataContext;
        }

        public int RowCount => _context.RowCount;
    }
}
