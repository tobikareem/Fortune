namespace Shared.Interfaces.Services
{
    public class DataContext
    {
        public int RowCount { get; }

        public DataContext()
        {
            RowCount = new Random().Next(1, 1000);
        }
    }
}
