
using Core.Models;
using Core.Interfaces.Repository;

namespace Shared.Services
{
    public class BlogPostService : IBlogPostService
    {
        BlogPost BlogPost { get; set; }

        public BlogPostService()
        {
            BlogPost = new BlogPost();
        }

        IEnumerable<BlogPost> BlogPostList { get; set; }

        public IEnumerable<BlogPost> GetAllBlogPosts()
        {
            var blogs =
                new List<BlogPost> {
                    new BlogPost {
                        Id = 1,
                        Title = "Hope",
                        Description = "Thinking about an Hopeful Situation",
                        Category = Core.CategoryEnum.Poetry,
                        Content =
                            @"<p>A thought</p>
                            <p>A Spirit</p>
                            <p>A memory in the dark</p>
                            <p>Words so precious they shatter so easily</p>
                            <p>&nbsp;</p>
                            <p>We search, we need</p>
                            <p>A special friend</p>
                            <p>A building hand to ease the strain</p>
                            <p>&nbsp;</p>
                            <p>And in the heat of the moment</p>
                            <p>The daily toil and trouble </p>
                            <p>Heartbeats drum up a rhythm of struggle</p>
                            <p>How can we turn that rhythm</p>
                            <p>Into a song of Hope?</p>",
                        Author = "Oluwatobi Kareem",
                        Image = "https://picsum.photos/200/300",
                        Date = "12/12/2019",
                        Tags = "poetry"
                    },
                    new BlogPost {
                        Id = 2,
                        Title = "Hero's Fall",
                        Description =
                            "A poetry dedicated to my late brother and his improptu death",
                        Category = Core.CategoryEnum.Poetry,
                        Content =
                            @"<p>When a hero fell</p>
                        <p>So did the walls mystic force and pain magnified</p>
                        <p>The greatest pain uncovered.</p>
                        <p>You told us not to fear even though you were young</p>
                       <p> I was confused to see you so weak on that ICU bed</p>
                        <p> When you almost gave up</p>
                       <p> When a hero fell</p>
                        <p>So did the stars that followed</p>
                        <p>And so the perception of tomorrow</p>
                        <p>The consecrated soul voyaged the soul of the might</p>
                        <p>We thought we were going to see forever</p>
                        <p>But forever is no more.</p>
                        <p>You remain in our heart forever</p>
                        <p>R.I.P. Tolu </p>",
                        Author = "Oluwatobi Kareem",
                        Image = "https://picsum.photos/200/300",
                        Date = "12/12/2019",
                        Tags = "poetry"
                    },
                    new BlogPost {
                        Id = 3,
                        Title = "Worry",
                        Description =
                            "Worrying may endure through out the nigt, but joy comes in the morning",
                        Category = Core.CategoryEnum.Poetry,
                        Content =
                            @"<p>My Unravel Thoughts</p>
                            <p>Ridden of serenity, Stript of its Gilding</p>
                            <p>To unburden my fragile mind</p>
                            <p>To take this rare soul</p>
                            <p>Out of the mound it reaches for.</p>
                            <p>&nbsp;</p>
                            <p>Can you&nbsp; keep a secret, </p>
                            <p>Can you know a thing and never say it again?</p>
                            <p>Shall I tell you the secret, If I do...</p>
                            <p>Will you get me out of this bird suit?</p>
                            <p>And If you do... then someday</p>
                            <p>Smiles shall upload our plagued faces</p>
                            <p>And the rain will drop to dry our tears.</p>
                            <p>&nbsp;</p>",
                        Author = "Oluwatobi Kareem",
                        Image = "https://picsum.photos/200/300",
                        Date = "12/12/2019",
                        Tags = "poetry"
                    }
                };

            return blogs;
        }
    }
}
