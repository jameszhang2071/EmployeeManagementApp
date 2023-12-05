using EmployeeManagementApp.Model;
using System.Text.RegularExpressions;

namespace EmployeeManagementApp.Views;

[QueryProperty(nameof(EmployeeId), "Id")]
public partial class EditEmployeePage : ContentPage
{
    private Employee employee;

    public EditEmployeePage()
	{
		InitializeComponent();
	}

	public string EmployeeId
	{ 
		set 
		{
			employee = EmployeeRepository.GetEmployeeById(int.Parse(value));
			if(employee != null)
			{
				employeeCtrl.firstName = employee.FirstName;
				employeeCtrl.lastName = employee.LastName;
				employeeCtrl.phoneNumber = employee.PhoneNumber;
			}
		}
	}

    private void employeeCtrl_OnSave(object sender, EventArgs e)
    {
		employee.FirstName = employeeCtrl.firstName;
        employee.LastName = employeeCtrl.lastName;
		employee.PhoneNumber = employeeCtrl.phoneNumber;
        EmployeeRepository.UpdateEmployee(employee);
        //EmployeeRepository.UpdateEmployee(employee.EmployeeId, employee);
        Shell.Current.GoToAsync("..");
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void employeeCtrl_OnError(object sender, string e)
    {
		DisplayAlert("Error", e, "OK");
    }

    private void employeeCtrl_OnDelete(object sender, EventArgs e)
    {
        if (employee != null)
        {
            EmployeeRepository.DeleteEmployee(employee.EmployeeId);
        }
        DisplayAlert("Info", "Successfully deleted!", "OK");
        Shell.Current.GoToAsync("..");
    }
}