using BethanyPieShopRazor.App.Models;
using BethanyPieShopRazor.App.Services;
using BethanysPieShopHRM.Shared.Domain;
using BethanysPieShopHRM.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace BethanyPieShopRazor.App.Pages
{
    public partial class EmployeeDetail
    {
        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }


        [Parameter]
        public string EmployeeId { get; set; }

        public Employee? Employee { get; set; } = new();

        public List<Marker> MapMarkers { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService
                .GetEmployeeDetails(int.Parse(EmployeeId));

            if (Employee.Longitude.HasValue && Employee.Latitude.HasValue)
            {
                MapMarkers = new List<Marker>
                {
                    new Marker{Description = $"{Employee.FirstName} {Employee.LastName}",  
                        ShowPopup = false, 
                        X = Employee.Longitude.Value, 
                        Y = Employee.Latitude.Value}
                };
            }
        }
    }
}
