using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Oqtane;

namespace MudOqtaneRazorControls.Controls.Theme.Base
{
    public class LoginBase: Oqtane.Themes.Controls.LoginBase
    {
        [Inject] protected IStringLocalizer<Login> Localizer { get;set; }
        [Inject] protected IStringLocalizer<SharedResources> SharedLocalizer{ get;set; }
        [Parameter]
        public bool ShowLogin { get; set; } = true;
    }
}
