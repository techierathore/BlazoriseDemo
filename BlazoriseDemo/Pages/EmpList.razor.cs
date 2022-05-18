using BlazoriseDemo.Data;
using BlazoriseDemo.Models;
using Microsoft.AspNetCore.Components;

namespace BlazoriseDemo.Pages
{
    public partial class EmpList
    {
        [Inject] private EmployeeData EmployeeData { get; set; }
        public string SelCountry { get; set; }
        public Employee SelectedObj { get; set; }
        protected EmpModel PlaceDialog { get; set; }
        private List<Employee> ObjectList = new();
        private List<Employee> inMemoryDataModels;
        protected override async Task OnInitializedAsync()
        {
            inMemoryDataModels = await EmployeeData.GetDataAsync();
            ObjectList = inMemoryDataModels.Take(50).ToList();
            await base.OnInitializedAsync();
        }
        protected void OpenEditDialog(long aObjectId)
        {
            PlaceDialog.ShowModal(aObjectId);
        }

        protected void OpenAddDialog()
        {
            PlaceDialog.ShowModal();
        }
        public void OnDialogClose()
        {
            StateHasChanged();
        }
    }
}
