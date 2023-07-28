using BethanyPieShopRazor.App.Models;
using BethanyPieShopRazor.App.Services;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BethanyPieShopRazor.App.Pages
{
    public partial class EmployeeDetail
    {
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }


        [Parameter]
        public string EmployeeId { get; set; }

        public Employee? Employee { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            //Employee = MockDataService.Employees
            //    .FirstOrDefault(e => e.EmployeeId == int.Parse(EmployeeId));

            //return base.OnInitializedAsync();
            Employee = await EmployeeDataService
                .GetEmployeeDetails(int.Parse(EmployeeId));
        }
    }
}
