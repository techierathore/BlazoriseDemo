using BlazoriseDemo.Data;
using BlazoriseDemo.Models;
using Microsoft.AspNetCore.Components;

namespace BlazoriseDemo.Pages
{
    public partial class EmpList: ComponentBase
    {
        [Inject] private EmployeeData EmployeeData { get; set; }
        
        public string SelCountry { get; set; }
        
        private Employee SelectedObj { get; set; }

        private Int32? _employeeId = 0;

        private EmpModel PlaceDialog;
        
        private List<Employee> ObjectList = new();
        
        private List<Employee> inMemoryDataModels;
        
        protected override async Task OnInitializedAsync()
        {
            inMemoryDataModels = await EmployeeData.GetDataAsync();

            ObjectList = inMemoryDataModels.Take(50).ToList();
        }
        
        private Task OpenEditDialog(Employee employee)
        {
            PlaceDialog.ShowEditModal(employee);

            StateHasChanged();

            return Task.CompletedTask;
        }

        private void OpenAddDialog()
        {
            PlaceDialog.ShowModal();
        }
        
        private void OnDialogClose()
        {
            _employeeId = null;
            StateHasChanged();
        }
    }
}
