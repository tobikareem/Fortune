using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Models;
using Shared.Interfaces.Repository;
namespace Web.Pages
{
    public class CreatePostModel : PageModel
    {

        [BindProperty] public Post UserPost { get; set; }
        private readonly IDataStore<Data.Entity.Post> _postRepository;
        private readonly IDataStore<Data.Entity.Category> _categoryRepo;

        public IEnumerable<Data.Entity.Category> Categories { get; set; }

        public CreatePostModel(IDataStore<Data.Entity.Post> _postRepository, IDataStore<Data.Entity.Category> _categoryRepo)
        {
            this._postRepository = _postRepository;
            this._categoryRepo = _categoryRepo;

            Categories = GetAllCategories();
            UserPost = new Post { IsPublished = true };
        }


        public IActionResult OnGet()
        {

            return Page();
        }

        public IActionResult OnPost()
        {

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            var post = new Data.Entity.Post
            {
                Title = UserPost.Title,
                Description = UserPost.Description,
                Content = UserPost.Content,
                UserId = "",
                CategoryId = Categories.First(x => x.Category1 == UserPost.Category.Category1).Id,
                IsPublished = true,
                Enabled = true,
                IsReviewPost = false,
                CreatedBy = "Oluwatobi Kareem",
                CreatedOn = DateTime.UtcNow,

                Category = Categories.First(x => x.Category1 == UserPost.Category.Category1) as Data.Entity.Category ?? new Data.Entity.Category(),

            };

            post.PostCategories.Add(new Data.Entity.PostCategory { CategoryId = post.Category.Id });
            post.UserPosts.Add(new Data.Entity.UserPost { UserId = post.UserId });

             _postRepository.AddEntity(post);


            return Page();

        }

        public IEnumerable<Data.Entity.Category> GetAllCategories()
        {
            if (Categories == null)
            {
                return _categoryRepo.GetAll();
            }

            return Categories;
        }
    }
}
