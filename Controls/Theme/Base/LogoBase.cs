using Microsoft.AspNetCore.Components;
using Oqtane.Services;
using Oqtane.Themes;
using Oqtane.UI;
using File = Oqtane.Models.File;

namespace MudOqtaneRazorControls.Controls.Theme.Base
{
    public class LogoBase : ThemeControlBase
    {
        [Inject] protected IFileService FileService { get; set; }

        public File file = null;

        protected override async Task OnParametersSetAsync()
        {
            if (PageState.Site.LogoFileId != null && file?.FileId != PageState.Site.LogoFileId.Value)
            {
                file = await FileService.GetFileAsync(PageState.Site.LogoFileId.Value);
            }
        }
    }
}
