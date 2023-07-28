using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BethanyPieShopRazor.App.Components
{
    public partial class QuickViewPopup
    {
        [Parameter]
        public Employee? Employee { get; set; }
        public Employee? _employee;

        protected override void OnParametersSet()
        {
            //After we get a parameter for this component,
            //The Employee param will have content, and then we can assign
            //it to our private field, and then, the "if" condition will
            //be set to "true" and the popup will display
            _employee = Employee;
        }

        public void Close()
        {
            _employee = null;
        }
    }
}
