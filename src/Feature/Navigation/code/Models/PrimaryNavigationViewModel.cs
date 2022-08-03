using Sitecore.Data.Items;
using System.Collections.Generic;

namespace GreenStreetCoffee.Feature.Navigation.Models
{
    public class PrimaryNavigationViewModel
    {
        public Item Datasource { get; set; }
        public IEnumerable<Link> Links { get; set; }
    }
}