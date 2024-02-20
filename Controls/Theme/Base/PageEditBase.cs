using Microsoft.AspNetCore.Components;
using Oqtane.Security;
using Oqtane.Services;
using Oqtane.Shared;


namespace MudOqtaneRazorControls.Controls.Theme.Base;
public class PageEditBase: Oqtane.Themes.ThemeControlBase
{

    [Inject] protected NavigationManager NavigationManager { get; set; }
    [Inject] protected IPageService PageService { get; set; }
    protected bool _showEditMode { get; set; }
    public bool AlarmOn { get; set; }
    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        _showEditMode = false;
        if (UserSecurity.IsAuthorized(PageState.User, PermissionNames.Edit, PageState.Page.PermissionList))
        {
            _showEditMode = true;
        }
        else
        {
            foreach (var module in PageState.Modules.Where(item => item.PageId == PageState.Page.PageId))
            {
                if (UserSecurity.IsAuthorized(PageState.User, PermissionNames.Edit, module.PermissionList))
                {
                    _showEditMode = true;
                    break;
                }
            }
        }
    }
    protected async Task ToggleEditMode(bool EditMode)
    {
        Oqtane.Models.Page page = null;
        if (PageState.Page.IsPersonalizable && PageState.User != null && UserSecurity.IsAuthorized(PageState.User, RoleNames.Registered))
        {
            page = await PageService.AddPageAsync(PageState.Page.PageId, PageState.User.UserId);
        }

        if (_showEditMode)
        {
            if (EditMode)
            {
                PageState.EditMode = false;
            }
            else
            {
                PageState.EditMode = true;
            }

            // preserve other querystring parameters
            if (PageState.QueryString.ContainsKey("edit")) PageState.QueryString.Remove("edit");
            PageState.QueryString.Add("edit", PageState.EditMode.ToString().ToLower());
            var url = PageState.Route.AbsolutePath + Utilities.CreateQueryString(PageState.QueryString);
            NavigationManager.NavigateTo(url);
        }
        else
        {
            if (PageState.Page.IsPersonalizable && PageState.User != null && UserSecurity.IsAuthorized(PageState.User, RoleNames.Registered))
            {
                PageState.EditMode = true;
                NavigationManager.NavigateTo(NavigateUrl(page.Path, "edit=" + ((PageState.EditMode) ? "true" : "false")));
            }
        }
    }
    //protected async Task<bool> ToggleEditMode(bool EditMode)
    //{
    //    Oqtane.Models.Page page = null;
    //    if (PageState.Page.IsPersonalizable && PageState.User != null && UserSecurity.IsAuthorized(PageState.User, RoleNames.Registered))
    //    {
    //        page = await PageService.AddPageAsync(PageState.Page.PageId, PageState.User.UserId);
    //    }

    //    if (_showEditMode)
    //    {
    //        if (EditMode)
    //        {

    //            PageState.EditMode = false;
    //        }
    //        else
    //        {
    //            PageState.EditMode = true;
    //        }

    //        // preserve other querystring parameters
    //        if (PageState.QueryString.ContainsKey("edit")) PageState.QueryString.Remove("edit");
    //        PageState.QueryString.Add("edit", PageState.EditMode.ToString().ToLower());
    //        var url = PageState.Route.AbsolutePath + Utilities.CreateQueryString(PageState.QueryString);
    //        NavigationManager.NavigateTo(url);
    //    }
    //    else
    //    {
    //        if (PageState.Page.IsPersonalizable && PageState.User != null && UserSecurity.IsAuthorized(PageState.User, RoleNames.Registered))
    //        {
    //            PageState.EditMode = true;
    //            NavigationManager.NavigateTo(NavigateUrl(page.Path, "edit=" + ((PageState.EditMode) ? "true" : "false")));
    //        }
    //    }
    //    return _showEditMode;
    //}

}
