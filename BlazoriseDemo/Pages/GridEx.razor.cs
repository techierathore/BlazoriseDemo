using BlazoriseDemo.Data;
using BlazoriseDemo.Models;
using Microsoft.AspNetCore.Components;
using Blazorise.DataGrid; 

namespace BlazoriseDemo.Pages
{
    public partial class GridEx
    {
        private DataGrid<Employee> dataGrid;
        private Employee selectedEmployee;
        [Inject] private EmployeeData EmployeeData { get; set; }
        private List<Employee> dataModels = new();
        private List<Employee> inMemoryDataModels;
        protected override async Task OnInitializedAsync()
        {
            inMemoryDataModels = await EmployeeData.GetDataAsync();
            dataModels = inMemoryDataModels.Take(50).ToList();
            await base.OnInitializedAsync();
        }
        private Task GridButtonClicked(Employee employee)
        {
            selectedEmployee = employee;
            
            StateHasChanged();

            return Task.CompletedTask;
        }
     }
}
