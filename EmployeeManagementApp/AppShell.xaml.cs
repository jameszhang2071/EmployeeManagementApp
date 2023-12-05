using EmployeeManagementApp.Views;

namespace EmployeeManagementApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(EmployeesPage), typeof(EmployeesPage));
            Routing.RegisterRoute(nameof(EditEmployeePage), typeof(EditEmployeePage));
            Routing.RegisterRoute(nameof(AddEmployeePage), typeof(AddEmployeePage));
        }
    }
}