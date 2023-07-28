using BethanyPieShopRazor.App.Models;
using BethanyPieShopRazor.App.Services;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BethanyPieShopRazor.App.Pages
{
    public partial class EmployeeOverview
    {
        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }
        public List<Employee> Employees { get; set; } = default!;
        private Employee? _selectedEmployee;
        private string Title = "Employee Overview";
        private string Description = "";
        protected override async Task OnInitializedAsync()
        {
            //Employees = MockDataService.Employees;
            Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
        }

        public void ShowQuickViewPopup(Employee selectedEmployee)
        {
            _selectedEmployee = selectedEmployee;
        }
    }
}
