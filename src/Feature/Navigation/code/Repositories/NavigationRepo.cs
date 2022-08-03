using GreenStreetCoffee.Feature.Navigation.Models;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenStreetCoffee.Feature.Navigation.Repositories
{
    public class NavigationRepo
    {
        public FooterViewModel BuildFooterViewModel()
        {
            try
            {
                Item datasource = RenderingContext.Current.Rendering.Item;
                if (datasource == null) return null;
                MultilistField socialLinksField = datasource.Fields["SocialLinks"];
                List<Item> socialLinkItems = new List<Item>();
                if (socialLinksField != null && socialLinksField.TargetIDs.Any())
                {
                    socialLinkItems = socialLinksField.GetItems().ToList();
                }
                return new FooterViewModel()
                {
                    DataSource = datasource,
                    SocialLinks = socialLinkItems
                };
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error("Error in BuildFooterViewModel method", ex, this);
                return null;
            }
        }

        public PrimaryNavigationViewModel BuildPrimaryNavigation()
        {
            try
            {
                var headerItem = RenderingContext.Current.Rendering.Item;
                if (headerItem == null) return null;

                MultilistField primaryLinkItems = headerItem.Fields["PrimaryNavigationLinks"];
                if (primaryLinkItems != null && primaryLinkItems.TargetIDs.Any())
                {
                    var links = primaryLinkItems.GetItems().Select(i => new Link
                    {
                        Item = i,
                        IsActive = IsActive(i),
                        SubNavigation = GetSubNavigation(i)
                    });

                    return new PrimaryNavigationViewModel()
                    {
                        Datasource = headerItem,
                        Links = links
                    };
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error("Error in BuildPrimaryNavigation method", ex, this);
            }

            return null;
        }

        public BreadcrumbViewModel BuildBreadcrumb()
        {
            try
            {
                string homepath = Sitecore.Context.Site.StartPath;
                Item contextItem = Sitecore.Context.Item;

                if (contextItem != null && !string.IsNullOrEmpty(homepath))
                {
                    Item homeItem = Sitecore.Context.Database.GetItem(homepath);
                    if (homeItem != null && homeItem.ID != contextItem.ID)
                    {
                        List<Item> braedcrumbList = contextItem.Axes.GetAncestors().SkipWhile(x => x.ID != homeItem?.ID).ToList();
                        braedcrumbList.Add(contextItem);

                        IEnumerable<BreadcrumbItem> breadcrumbItems = braedcrumbList.Select(i => new BreadcrumbItem
                        {
                            PageItem = i,
                            PageUrl = LinkManager.GetItemUrl(i),
                            Active = (i.ID == contextItem.ID)
                        });
                        return new BreadcrumbViewModel()
                        {
                            BreadcrumbItems = breadcrumbItems,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error("Error in BuildPrimaryNavigation method", ex, this);
            }

            return null;
        }

        private bool IsActive(Item item)
        {
            var currentPageItem = RenderingContext.Current.ContextItem;
            LinkField link = item.Fields["NavigationLink"];
            string linkItemId = link.TargetID.ToString();
            if (linkItemId.Equals(currentPageItem.ID.ToString()))
            {
                return true;
            }
            return false;
        }

        private IEnumerable<Link> GetSubNavigation(Item i)
        {
            List<Link> SubNavigation = new List<Link>();
            MultilistField subNavItems = i.Fields["SubNavigationLinks"];
            if (subNavItems != null || subNavItems.TargetIDs.Any())
            {
                foreach (Item subNavItem in subNavItems.GetItems())
                {
                    SubNavigation.Add(new Link
                    {
                        Item = subNavItem,
                        SubNavigation = null,
                        IsActive = IsActive(subNavItem)
                    });
                }
            }

            return SubNavigation;
        }
    }
}