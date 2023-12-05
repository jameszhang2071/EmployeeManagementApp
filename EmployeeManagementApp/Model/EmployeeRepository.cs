using SQLite;

namespace EmployeeManagementApp.Model
{

    public static class EmployeeRepository
    {
        private static readonly SQLiteConnection _database;
        private const string _databaseName = "ROIEmployees.db3";
        static EmployeeRepository()
        {
            _database = new SQLiteConnection(Path.Combine(FileSystem.AppDataDirectory, _databaseName));
            _database.CreateTable<Department>();
            _database.CreateTable<Address>();
            _database.CreateTable<Employee>();
        }

        public static List<Employee> GetEmployees()
        {
            return _database.Table<Employee>().ToList();
        }

        public static Employee GetEmployeeById(int id)
        {
            return _database.Table<Employee>().FirstOrDefault(employee => employee.EmployeeId == id);
        }

        public static Department GetDepartmentById(int id)
        {
            return _database.Table<Department>().FirstOrDefault(department => department.DepartmentId == id);
        }

        public static Address GetAddressById(int id)
        {
            return _database.Table<Address>().FirstOrDefault(address => address.AddressId == id);
        }

        public static void UpdateEmployee(Employee employee)
        {

            _database.Update(employee);
        }

        public static void AddEmployee(Employee employee)
        {
            _database.Insert(employee);
        }

        public static void DeleteEmployee(int employeeId)
        {
            _database.Delete<Employee>(employeeId);
        }

        // Helper methods to ensure related entities exist
        public static Department CheckDepartmentExists(Department department)
        {
            if (department != null)
            {
                var existingDepartment = _database.Find<Department>(department.DepartmentId);
                if (existingDepartment == null)
                {
                    _database.Insert(department);
                }
            }
             return department;
        }

        public static Address CheckAddressExists(Address address)
        {
            if (address != null)
            {
                var existingAddress = _database.Find<Address>(address.AddressId);
                if (existingAddress == null)
                {
                    _database.Insert(address);
                }
            }
            return address;
        }

    }
}
