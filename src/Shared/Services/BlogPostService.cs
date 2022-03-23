
using Core.Models;
using Shared.Interfaces.Repository;

namespace Shared.Services
{
    public class BlogPostService : IBlogPostService
    {
        public BlogPost BlogPost { get; set; }

        public BlogPostService()
        {
            BlogPost = new BlogPost();
        }

        public IEnumerable<BlogPost> BlogPostList { get; set; }

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
                            @"
                        When a hero fell
                        So did the walls mystic force and pain magnified
                        The greatest pain uncovered.
                        You told us not to fear even though you were young
                         I was confused to see you so weak on that ICU bed
                         When you almost gave up
                         When a hero fell
                        So did the stars that followed
                        And so the perception of tomorrow
                        The consecrated soul voyaged the soul of the might
                        We thought we were going to see forever
                        But forever is no more.
                        You remain in our heart forever
                        R.I.P. Tolu
                        ",
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
                            @"
                            My Unravel Thoughts
                            Ridden of serenity, Stript of its Gilding
                            To unburden my fragile mind
                            To take this rare soul
                            Out of the mound it reaches for.
                            &nbsp;
                            Can you&nbsp; keep a secret,
                            Can you know a thing and never say it again?
                            Shall I tell you the secret, If I do...
                            Will you get me out of this bird suit?
                            And If you do... then someday
                            Smiles shall upload our plagued faces
                            And the rain will drop to dry our tears.
                            &nbsp;",
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
