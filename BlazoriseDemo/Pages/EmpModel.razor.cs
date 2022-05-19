using Blazorise;
using BlazoriseDemo.Data;
using BlazoriseDemo.Models;
using Microsoft.AspNetCore.Components;
namespace BlazoriseDemo.Pages
{
    public partial class EmpModel
    {
        private Modal PlaceModal = new();

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        [Parameter] public Int32? EmployeeId { get; set; } = 0;
        
        public string PageHeader { get; set; }

        private Employee? displayObject;

        [Inject] private EmployeeData EmployeeData { get; init; }
        
        private List<Employee> ObjectList = new();
        
        private List<Employee> inMemoryDataModels;

        protected override async Task OnInitializedAsync()
        {
            inMemoryDataModels = await EmployeeData.GetDataAsync();
            ObjectList = inMemoryDataModels.Take(50).ToList();
        }
        
        protected override Task OnParametersSetAsync()
        {
            displayObject ??= (from Emps in inMemoryDataModels
                where Emps.Id == EmployeeId
                select Emps).FirstOrDefault();
        
            return Task.CompletedTask;
        }


        public Task ShowEditModal(Employee employee)
        {
            displayObject = employee;

            PageHeader = "Edit Place Details";
           
            return PlaceModal.Show();
        }
        public Task ShowModal()
        {
            PageHeader = "Add New Place";
            return PlaceModal.Show();
        }
        public void CloseModal()
        {
            PlaceModal.Hide();
        }
    }
}
