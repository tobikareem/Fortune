using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Interfaces.Services;
using Shared.Interfaces.Repository;
using Data.Entity;

namespace Web.Pages
{
    public class HomeModel : PageModel
    {
        private readonly DataContext _dataContext;
        private readonly DataReposit _dataReposit;

        private readonly IDataStore<Post> dataPost;

        public List<Post> DisplayPosts { get; set; }
        public int DataRowCount { get; set; }
        public int RepoRowCount { get; set; }

        public HomeModel(DataReposit dataReposit, DataContext dataContext, IDataStore<Post> dataStore)
        {
            dataPost = dataStore;

            _dataContext = dataContext;
            _dataReposit = dataReposit;
        }

        public void OnGet()
        {
            var posts = dataPost.GetAll();

            DisplayPosts = posts.Where(x => string.Compare(x.Category.Category1, "mindfeed", StringComparison.CurrentCultureIgnoreCase) == 0 && x.Enabled).ToList();

            DataRowCount = _dataContext.RowCount;
            RepoRowCount = _dataReposit.RowCount;
        }
    }
}
