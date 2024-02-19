using MudBlazor;
using Oqtane.Themes;
using Oqtane.UI;
namespace MudOqtaneRazorControls.Controls.Theme
{
    public partial class Breadcrumbs : ThemeControlBase
    {
        protected List<BreadcrumbItem>? _items;

        protected override void OnInitialized()
        {
            _items = GetBreadCrumbPages().Reverse()
                .Select(bc => new BreadcrumbItem(bc.Name, href: bc.Path))
                .ToList();

            base.OnInitialized();
        }

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
