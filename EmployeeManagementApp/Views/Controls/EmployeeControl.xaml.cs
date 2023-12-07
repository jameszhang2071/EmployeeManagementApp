using EmployeeManagementApp.Model;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace EmployeeManagementApp.Views.Controls;

/// <summary>
/// Create reusable control
/// </summary>
public partial class EmployeeControl : ContentView
{
    public event EventHandler<string> OnError;
    public event EventHandler<EventArgs> OnSave;
    public event EventHandler<EventArgs> OnDelete;
    public event EventHandler<EventArgs> OnCancel;

    public List<Department> Departments { get; set; }

    public EmployeeControl()
	{
		InitializeComponent();
    }

    public string firstName
    {
        get => entryFirstName.Text;
        set => entryFirstName.Text = value;
    }

    public string lastName
    {
        get => entryLastName.Text;
        set => entryLastName.Text = value;
    }

    public string phoneNumber
    {
        get => entryPhoneNumber.Text;
        set => entryPhoneNumber.Text = value;
    }

    public Department department
    {
        get => (Department)pickerDepartments.SelectedItem;
        set => pickerDepartments.SelectedItem = value;
    }

    public string street
    {
        get => entryStreet.Text;
        set => entryStreet.Text = value;
    }

    public string city
    {
        get => entryCity.Text;
        set => entryCity.Text = value;
    }

    public string state
    {
        get => entryState.Text;
        set => entryState.Text = value;
    }

    public string zip
    {
        get => entryZip.Text;
        set => entryZip.Text = value;
    }
    public string country
    {
        get => entryCountry.Text;
        set => entryCountry.Text = value;
    }

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        // Define a simple regex pattern for a valid phone number.
        // Assumes a 10-digit phone number.
        string pattern = @"^\d{10}$";

        // Validate first name and minimum length should be 2
        if (string.IsNullOrEmpty(entryFirstName.Text))
        {
            OnError?.Invoke(sender, "Frist Name is required!");
            return;
        }

        // Validate last name and minimum length should be 2
        if (string.IsNullOrEmpty(entryLastName.Text))
        {
            OnError?.Invoke(sender, "Last Name is required!");
            return;
        }

        if (string.IsNullOrEmpty(entryPhoneNumber.Text) || !Regex.IsMatch(entryPhoneNumber.Text, pattern))
        {
            OnError?.Invoke(sender, "Invalid phone number!");
            return;
        }

        if (string.IsNullOrEmpty(entryZip.Text) || !Regex.IsMatch(entryZip.Text, @"^\d{4}$"))
        {
            OnError?.Invoke(sender, "Invalid Zip Code(4 digits)!");
            return;
        }

        OnSave?.Invoke(sender, e);
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        OnCancel?.Invoke(sender, e);
    }

    private void btnDelete_Clicked(object sender, EventArgs e)
    {
        OnDelete?.Invoke(sender, e);
    }

    public void LoadDepartments(Department selectedDepartment)
    {
        Departments = EmployeeRepository.GetDepartments();
        pickerDepartments.ItemsSource = Departments;
        if (selectedDepartment != null)
        {
            pickerDepartments.SelectedItem = selectedDepartment.DepartmentId;
            //selectedDepartmentLabel.Text = pickerDepartments.SelectedItem.ToString();
        }
        else
        {
            pickerDepartments.SelectedIndex = -1;
        }
        //pickerDepartments.ItemDisplayBinding = new Binding("DepartmentName");
    }

    private void pickerDepartments_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        //int selectedIndex = picker.SelectedIndex
        if (picker.SelectedItem != null)
        {
            selectedDepartmentLabel.Text = $"Selected Department: {((Department)picker.SelectedItem).DepartmentName}";
        }
        else
        {
            selectedDepartmentLabel.Text = string.Empty;
        }
    }
}