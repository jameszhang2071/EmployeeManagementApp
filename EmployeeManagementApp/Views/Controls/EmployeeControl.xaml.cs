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
    public EmployeeControl()
	{
		InitializeComponent();
    }

	public string firstName
	{
		get
		{
            return entryFirstName.Text;
		}
		set
		{
			entryFirstName.Text = value;
		}
    }

    public string lastName
    {
        get
        {
            return entryLastName.Text;
        }
        set
        {
            entryLastName.Text = value;
        }
    }

    public string phoneNumber
    {
        get
        {
            return entryPhoneNumber.Text;
        }
        set
        {
            entryPhoneNumber.Text = value;
        }
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
}