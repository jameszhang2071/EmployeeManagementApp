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
                var department = EmployeeRepository.GetDepartmentById(employee.DepartmentId);
                if (department != null)
                {
                    employeeCtrl.department = department.DepartmentName;
                }
                else
                {
                    employeeCtrl.department = string.Empty;
                }

                var address = EmployeeRepository.GetAddressById(employee.AddressId);

                if (address != null)
                {
                    employeeCtrl.street = address.Street;
                    employeeCtrl.city = address.City;
                    employeeCtrl.state = address.State;
                    employeeCtrl.zip = address.Zip;
                    employeeCtrl.country = address.Country;
                }
                else
                {
                    employeeCtrl.street = string.Empty;
                    employeeCtrl.city = string.Empty;
                    employeeCtrl.state = string.Empty;
                    employeeCtrl.zip = string.Empty;
                    employeeCtrl.country = string.Empty;
                }
			}
		}
	}

    private void employeeCtrl_OnSave(object sender, EventArgs e)
    {
		employee.FirstName = employeeCtrl.firstName;
        employee.LastName = employeeCtrl.lastName;
		employee.PhoneNumber = employeeCtrl.phoneNumber;

        var department = new Department { DepartmentName = employeeCtrl.department };
        department = EmployeeRepository.CheckDepartmentExists(department);

        var address = new Address
        {
            Street = employeeCtrl.street,
            City = employeeCtrl.city,
            State = employeeCtrl.state,
            Zip = employeeCtrl.zip,
            Country = employeeCtrl.country
        };

        address = EmployeeRepository.CheckAddressExists(address);

        employee.DepartmentId = department.DepartmentId;
        employee.AddressId = address.AddressId;

        EmployeeRepository.UpdateEmployee(employee);

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