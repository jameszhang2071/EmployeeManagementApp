using Android.Provider;
using EmployeeManagementApp.Model;
using System.Collections.ObjectModel;


namespace EmployeeManagementApp.Views;

public partial class EmployeesPage : ContentPage
{
	public EmployeesPage()
	{
		InitializeComponent();
    }

    // Refreshing employees list
    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadEmployees();
    }

    private async void listEmployeess_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if(listEmployees.SelectedItem != null)
        {
            // Once selected, navigate to edit detail page
            await Shell.Current.GoToAsync($"{nameof(EditEmployeePage)}?Id={((Employee)listEmployees.SelectedItem).EmployeeId}");
        }
    }

    private void listEmployeess_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listEmployees.SelectedItem = null;
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddEmployeePage));
    }

    private void LoadEmployees()
    {
        var employees = new ObservableCollection<Employee>(EmployeeRepository.GetEmployees());
        listEmployees.ItemsSource = employees;
    }
}