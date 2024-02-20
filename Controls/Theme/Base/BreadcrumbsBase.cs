using MudBlazor;
using Oqtane.Themes;
using Oqtane.UI;
namespace MudOqtaneRazorControls.Controls.Theme.Base
{
    public class BreadcrumbsBase : ThemeControlBase
    {
        protected List<BreadcrumbItem>? Items;

        protected override void OnParametersSet()
        {
            Items = GetBreadCrumbPages().Reverse()
                .Select(bc => new BreadcrumbItem(bc.Name, href: bc.Path))
                .ToList(); 
            base.OnParametersSet();
        }
        //protected override void OnInitialized()
        //{
        //    Items = GetBreadCrumbPages().Reverse()
        //        .Select(bc => new BreadcrumbItem(bc.Name, href: bc.Path))
        //        .ToList();

        //    base.OnInitialized();
        //}

        private IEnumerable<Oqtane.Models.Page> GetBreadCrumbPages()
        {
            var page = base.PageState.Page;
            do
            {
                yield return page;
                page = base.PageState.Pages.FirstOrDefault(p => page != null && p.PageId == page.ParentId);
            } while (page != null);
        }

    }
}
