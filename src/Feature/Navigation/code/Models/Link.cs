using Sitecore.Data.Items;
using System.Collections.Generic;

namespace GreenStreetCoffee.Feature.Navigation.Models
{
    public class Link
    {
        public Item Item { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<Link> SubNavigation { get; set; }
    }
}