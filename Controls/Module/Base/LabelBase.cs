using Microsoft.AspNetCore.Components;
using Oqtane.Modules.Controls;

namespace MudOqtaneRazorControls.Controls.Module.Base
{
    public class LabelBase : LocalizableComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string For { get; set; } // optional - the id of the associated input control for accessibility

        [Parameter]
        public string Class { get; set; } // optional - CSS classes

        [Parameter]
        public string HelpText { get; set; } // optional - tooltip for this label

        protected string _spanclass;
        protected string LabelClass;
        protected string _helptext = string.Empty;

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (!string.IsNullOrEmpty(HelpText))
            {
                _helptext = Localize(nameof(HelpText), HelpText);
                LabelClass = "form-label";

                var spanclass = (!string.IsNullOrEmpty(Class)) ? " " + Class : "";
                _spanclass = "app-tooltip" + spanclass;
            }
            else
            {
                var labelclass = (!string.IsNullOrEmpty(Class)) ? " " + Class : "";
                LabelClass = "form-label" + labelclass;
            }

            var text = Localize("Text", String.Empty);
            if (!string.IsNullOrEmpty(text))
            {
                ChildContent = new RenderFragment(builder =>
                {
                    builder.AddMarkupContent(0, $"<text>{text}</text>");
                });
            }
        }
    }
}
