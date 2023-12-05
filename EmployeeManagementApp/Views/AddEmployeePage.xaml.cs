using EmployeeManagementApp.Model;

namespace EmployeeManagementApp.Views;

public partial class AddEmployeePage : ContentPage
{
	public AddEmployeePage()
	{
		InitializeComponent();
    }

    private void employeeCtrl_OnSave(object sender, EventArgs e)
    {
        EmployeeRepository.AddEmployee(new Model.Employee
        {
            FirstName = employeeCtrl.firstName, 
            LastName = employeeCtrl.lastName,
            PhoneNumber = employeeCtrl.phoneNumber
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