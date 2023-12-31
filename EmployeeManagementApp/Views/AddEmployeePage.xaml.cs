using EmployeeManagementApp.Model;
using EmployeeManagementApp.Views.Controls;
using System.Collections.ObjectModel;

namespace EmployeeManagementApp.Views;

public partial class AddEmployeePage : ContentPage
{

    public AddEmployeePage()
	{
		InitializeComponent();
        // Hide Delete Button in Add Employee page.
        employeeCtrl.btnDelete.IsVisible = false;
        employeeCtrl.LoadDepartments(null);
    }

    private void employeeCtrl_OnSave(object sender, EventArgs e)
    {
     
        var department = employeeCtrl.department;

        var address = new Address
        {
            Street = employeeCtrl.street,
            City = employeeCtrl.city,
            State = employeeCtrl.state,
            Zip = employeeCtrl.zip,
            Country = employeeCtrl.country
        };

        address = EmployeeRepository.CheckAddressExists(address);

        EmployeeRepository.AddEmployee(new Model.Employee
        {
            FirstName = employeeCtrl.firstName, 
            LastName = employeeCtrl.lastName,
            PhoneNumber = employeeCtrl.phoneNumber,
            DepartmentId = department.Id,
            AddressId = address.AddressId,
        });

        Shell.Current.GoToAsync("..");
    }

    private void employeeCtrl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(EmployeesPage)}");
    }

    private void employeeCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}