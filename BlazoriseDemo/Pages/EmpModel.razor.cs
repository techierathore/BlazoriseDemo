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
        public Employee PageObj { get; set; }
        public string PageHeader { get; set; }
        [Inject] private EmployeeData EmployeeData { get; set; }
        private List<Employee> ObjectList = new();
        private List<Employee> inMemoryDataModels;
        protected override async Task OnInitializedAsync()
        {
            inMemoryDataModels = await EmployeeData.GetDataAsync();
            ObjectList = inMemoryDataModels.Take(50).ToList();
            await base.OnInitializedAsync();
        }
        public Task ShowModal(long aObjectId)
        {
            PageHeader = "Edit Place Details";
            PageObj = (from Emps in inMemoryDataModels
                       where Emps.Id == aObjectId
                       select Emps).FirstOrDefault();
            return PlaceModal.Show();
        }
        public Task ShowModal()
        {
            PageHeader = "Add New Place";
            PageObj = new Employee();
            return PlaceModal.Show();
        }
        public void CloseModal()
        {
            PlaceModal.Hide();
        }
    }
}
