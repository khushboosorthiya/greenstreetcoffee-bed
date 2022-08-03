using System.Collections.Generic;

namespace GreenStreetCoffee.Feature.Navigation.Models
{
    public class BreadcrumbViewModel
    {
        public IEnumerable<BreadcrumbItem> BreadcrumbItems { get; set; }
    }
}