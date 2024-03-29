﻿using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Oqtane.Modules;
namespace MudOqtaneRazorControls.Controls.Module.Base;
public class AuditInfoBase: ModuleControlBase
{
    [Inject] public IStringLocalizer<Oqtane.Modules.Controls.AuditInfo> Localizer { get; set; }

    public string _text = string.Empty;

    [Parameter]
    public string CreatedBy { get; set; }

    [Parameter]
    public DateTime? CreatedOn { get; set; }

    [Parameter]
    public string ModifiedBy { get; set; }

    [Parameter]
    public DateTime? ModifiedOn { get; set; }

    [Parameter]
    public string DeletedBy { get; set; }

    [Parameter]
    public DateTime? DeletedOn { get; set; }

    [Parameter]
    public bool IsDeleted { get; set; }

    [Parameter]
    public string Style { get; set; }

    [Parameter]
    public string DateTimeFormat { get; set; } = "MMM dd yyyy HH:mm:ss";

    protected override void OnParametersSet()
    {
        _text = string.Empty;
        if (!String.IsNullOrEmpty(CreatedBy) || CreatedOn.HasValue)
        {
            _text += $"<p style=\"{Style}\">{Localizer["Created"]} ";

            if (!String.IsNullOrEmpty(CreatedBy))
            {
                _text += $" {Localizer["By"]} <b>{CreatedBy}</b>";
            }

            if (CreatedOn != null)
            {
                _text += $" {Localizer["On"]} <b>{CreatedOn.Value.ToString(DateTimeFormat)}</b>";
            }

            _text += "</p>";
        }

        if (!String.IsNullOrEmpty(ModifiedBy) || ModifiedOn.HasValue)
        {
            _text += $"<p style=\"{Style}\">{Localizer["LastModified"]} ";

            if (!String.IsNullOrEmpty(ModifiedBy))
            {
                _text += $" {Localizer["By"]} <b>{ModifiedBy}</b>";
            }

            if (ModifiedOn != null)
            {
                _text += $" {Localizer["On"]} <b>{ModifiedOn.Value.ToString(DateTimeFormat)}</b>";
            }

            _text += "</p>";
        }

        if (!String.IsNullOrEmpty(DeletedBy) || DeletedOn.HasValue)
        {
            _text += $"<p style=\"{Style}\">{Localizer["Deleted"]} ";

            if (!String.IsNullOrEmpty(DeletedBy))
            {
                _text += $" {Localizer["By"]} <b>{DeletedBy}</b>";
            }

            if (DeletedOn != null)
            {
                _text += $" {Localizer["On"]} <b>{DeletedOn.Value.ToString(DateTimeFormat)}</b>";
            }

            _text += "</p>";
        }
    }
}
