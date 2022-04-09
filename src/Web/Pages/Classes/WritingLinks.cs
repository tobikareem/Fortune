using Data.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Pages.Classes
{
    public static class WritingLinks
    {
        public static Post Post { get; set; } = new Post();
        public static string EditPage => "EditPost";
        public static string NotificationPage => "Notification";

        public static string SetEditPageActive(ViewContext viewContext) => PageNavClass(viewContext, EditPage);
        public static string SetNotificationPageActive(ViewContext viewContext) => SomethingIsClicked(viewContext, NotificationPage);

        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                             ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return (string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null) ?? string.Empty;
        }

        public static string SomethingIsClicked(ViewContext context, string page)
        {
            return string.Empty;
        }
    }
}
