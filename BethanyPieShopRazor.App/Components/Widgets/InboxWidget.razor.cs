using Microsoft.AspNetCore.Components;

namespace BethanyPieShopRazor.App.Components.Widgets
{
    public partial class InboxWidget
    {
        [Inject]
        public ApplicationState AppState { get; set; }
        public int MessageCount { get; set; } = 0;

        protected override void OnInitialized()
        {
            MessageCount = AppState.NumberOfMessages;
        }
    }
}
