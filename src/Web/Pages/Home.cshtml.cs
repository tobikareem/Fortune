using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Interfaces.Services;

namespace Web.Pages
{
    public class HomeModel : PageModel
    {
        private readonly DataContext _dataContext;
        private readonly DataReposit _dataReposit;


        public int DataRowCount { get; set; }
        public int RepoRowCount { get; set; }
        public HomeModel( DataReposit dataReposit, DataContext dataContext)
        {
            _dataContext = dataContext;
            _dataReposit = dataReposit;
        }
        public void OnGet()
        {
            DataRowCount = _dataContext.RowCount;
            RepoRowCount = _dataReposit.RowCount;
        }
    }
}
