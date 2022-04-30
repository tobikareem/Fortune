using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Pages.Classes
{
    public static class BreadCrumbs
    {

        public static string Home => "Home";
        public static string About => "About";
        public static string BlogPost => "BlogPost";
        public static string Contact => "Contact";
        public static string Connections => "Connections";
        public static string CreatePost => "CreatePost";
        public static string Dashboard => "Dashboard";
        public static string Developer => "Developer";
        public static string EditPost => "EditPost";
        public static string Notifications => "Notifications";
        public static string Suggestions => "Suggestions";
        public static string Writer => "Writer";

        public static (string display, string active) AddDisplayForHome(ViewContext context) => AddingDisplayClass(context, Home);
        public static (string display, string active) AddDisplayForAbout(ViewContext context) => AddingDisplayClass(context, About);
        public static (string display, string active) AddDisplayForBlogPost(ViewContext context) => AddingDisplayClass(context, BlogPost);
        public static (string display, string active) AddDisplayForContact(ViewContext context) => AddingDisplayClass(context, Contact);
        public static (string display, string active) AddDisplayForCreatePost(ViewContext context) => AddingDisplayClass(context, CreatePost);
        public static (string display, string active) AddDisplayForDashboard(ViewContext context) => AddingDisplayClass(context, Dashboard);
        public static (string display, string active) AddDisplayForDeveloper(ViewContext context) => AddingDisplayClass(context, Developer);
        public static (string display, string active) AddDisplayForEditPost(ViewContext context) => AddingDisplayClass(context, EditPost);
        public static (string display, string active) AddDisplayForNotifications(ViewContext context) => AddingDisplayClass(context, Notifications);
        public static (string display, string active) AddDisplayForSuggestions(ViewContext context) => AddingDisplayClass(context, Suggestions);
        public static (string display, string active) AddDisplayForWriter(ViewContext context) => AddingDisplayClass(context, Writer);
        public static (string display, string active) AddDisplayForConnections(ViewContext context) => AddingDisplayClass(context, Connections);


        private static (string display, string active) AddingDisplayClass(ViewContext viewContext, string page)
        {
            var display = "none";
            var active = string.Empty;

            var activePage = viewContext.ViewData["ActivePage"] as string
                             ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);

            if (!string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase))
            {
                return (display, active);
            }

            display = "block";
            active = "active";

            return (display, active);
        }

        public static string GetAriaCurrent(ViewContext viewContext, string page)
        {
            const string ariaPage = "page";
            var aria = AddingDisplayClass(viewContext, page).display == "block" ? $"aria-current={ariaPage}" : string.Empty;

            return aria;
        }

    }
}
