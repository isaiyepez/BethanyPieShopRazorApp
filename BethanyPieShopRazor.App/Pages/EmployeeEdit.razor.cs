using BethanyPieShopRazor.App.Services;
using BethanysPieShopHRM.Shared.Domain;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BethanyPieShopRazor.App.Pages
{
    public partial class EmployeeEdit
    {

        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }

        [Inject]
        public ICountryDataService? CountryDataService { get; set; }

        [Inject]
        public IJobCategoryDataService? JobCategoryDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ILocalStorageService LocalStorageService { get; set; }

        [Parameter]
        public string? EmployeeId { get; set; }

        public Employee Employee { get; set; } = new();
        public List<Country> Countries { get; set; } = new();

        public List<JobCategory> JobCategories { get; set; } = new();

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;
        private IBrowserFile selectedFile;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            Countries = (await CountryDataService
                .GetAllCountries()).ToList();                       

            JobCategories = (await JobCategoryDataService
                .GetAllJobCategories()).ToList();

            int.TryParse(EmployeeId, out var employeeId);

            if (employeeId == 0) //new employee is being created
            {
                //add some defaults
                Employee = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };
            }
            else
            {
                Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            }
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;

            if (Employee.EmployeeId == 0)//New
            {
                if (selectedFile != null)
                {
                    var file = selectedFile;
                    Stream stream = file.OpenReadStream();
                    MemoryStream ms = new();
                    await stream.CopyToAsync(ms);
                    stream.Close();

                    Employee.ImageName = file.Name;
                    Employee.ImageContent = ms.ToArray();
                }

                var addedEmployee = await EmployeeDataService
                    .AddEmployee(Employee);
                if (addedEmployee != null)
                {
                    StatusClass = "alert-success";
                    Message = "New employee added successfully.";
                    Saved = true;

                    await LocalStorageService.ClearAsync();

                } else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new employee. Please try again.";
                    Saved = false;
                }
            }
            else //Update
            {                
                await EmployeeDataService.UpdateEmployee(Employee);
                StatusClass = "alert-success";
                Message = "Updated employee successfully.";
                Saved = true;
                await LocalStorageService.ClearAsync();
            }
        }

        protected async Task HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeleteEmployee()
        {
            await EmployeeDataService.DeleteEmployee(Employee.EmployeeId);

            StatusClass = "alert-success";
            Message = "Deleted successfully";
            Saved = true;
            await LocalStorageService.ClearAsync();
        }

        private void OnInputFileChange(InputFileChangeEventArgs e)
        {
            selectedFile = e.File;
            StateHasChanged();
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/employeeoverview");
        }
    }
}
 