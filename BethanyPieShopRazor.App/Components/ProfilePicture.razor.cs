using Microsoft.AspNetCore.Components;

namespace BethanyPieShopRazor.App.Components
{
    public partial class ProfilePicture
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

    }
}
