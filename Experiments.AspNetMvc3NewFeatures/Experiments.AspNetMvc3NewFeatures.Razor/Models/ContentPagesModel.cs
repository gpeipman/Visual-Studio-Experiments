namespace Experiments.AspNetMvc3NewFeatures.Razor.Models
{
    public class ContentPagesModel
    {
        public ContentPage GetAboutPage()
        {
            var page = new ContentPage();
            page.Title = "About us";
            page.Description = "This page introduces us";

            return page;
        }
    }
}