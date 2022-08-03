using Sitecore.Data.Items;

namespace GreenStreetCoffee.Feature.Navigation.Models
{
    public class BreadcrumbItem
    {
        public Item PageItem { get; set; }
        public string PageUrl { get; set; }
        public bool Active { get; set; }
    }
}