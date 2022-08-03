using Sitecore.Data.Items;
using System.Collections.Generic;

namespace GreenStreetCoffee.Feature.Navigation.Models
{
    public class FooterViewModel
    {
        public Item DataSource { get; set; }

        public List<Item> SocialLinks { get; set; }
    }
}