using SQLite;

namespace EmployeeManagementApp.Model
{

    public static class EmployeeRepository
    {
        private static readonly SQLiteConnection _database;
        private const string _databaseName = "ROIEmployees.db3";
        private static string _databaseFile = Path.Combine(FileSystem.AppDataDirectory, _databaseName);
        static EmployeeRepository()
        {

            //if (File.Exists(_databaseFile))
            //{
            //    File.Delete(_databaseFile);
            //}

            _database = new SQLiteConnection(_databaseFile);
            _database.CreateTable<Department>();
            _database.CreateTable<Address>();
            _database.CreateTable<Employee>();
            PopulateDepartments();
        }

        public static List<Employee> GetEmployees()
        {
            return _database.Table<Employee>().ToList();
        }

        public static List<Department> GetDepartments()
        {
            return _database.Table<Department>().ToList();
        }

        // Pre populate department table
        public static void PopulateDepartments()
        {
            var departments = new List<Department>
            {
                new Department { Id = 1, DepartmentId = 0, DepartmentName = "General" },
                new Department { Id = 2, DepartmentId = 1, DepartmentName = "Information Communications Technology" },
                new Department { Id = 3, DepartmentId = 2, DepartmentName = "Finance" },
                new Department { Id = 4, DepartmentId = 3, DepartmentName = "Marketing" },
                new Department { Id = 5, DepartmentId = 4, DepartmentName = "Human Resources" }
            };
            foreach (var department in departments)
            {
                // Check department exsits in Database or not, if not then insert into table.
                CheckDepartmentExists(department);
            }
            //_database.InsertAll(departments);
        }

        public static Employee GetEmployeeById(int id)
        {
            return _database.Table<Employee>().FirstOrDefault(employee => employee.EmployeeId == id);
        }

        public static Department GetDepartmentById(int id)
        {
            return _database.Table<Department>().FirstOrDefault(department => department.Id == id);
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

        // Helper methods to ensure department entities exist
        public static Department CheckDepartmentExists(Department department)
        {
            if (department != null)
            {
                var existingDepartment = _database.Find<Department>(department.Id);
                if (existingDepartment == null)
                {
                    _database.Insert(department);
                }
            }
             return department;
        }

        // Helper methods to ensure address entities exist
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
