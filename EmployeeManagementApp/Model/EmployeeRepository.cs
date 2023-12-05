using SQLite;

namespace EmployeeManagementApp.Model
{

    public static class EmployeeRepository
    {
        private static readonly SQLiteConnection _database;

        static EmployeeRepository()
        {
            _database = new SQLiteConnection(Path.Combine(FileSystem.AppDataDirectory, "employees.db3"));
            _database.CreateTable<Employee>();
            _database.CreateTable<Department>();
            _database.CreateTable<Address>();
        }

        public static List<Employee> _employees = new List<Employee>()
        {
            new Employee() { EmployeeId = 1, FirstName="Test1", LastName="Last", PhoneNumber="1" },
            new Employee() { EmployeeId = 2, FirstName="Test2", LastName="Last", PhoneNumber="2" },
            new Employee() { EmployeeId = 3, FirstName="Test3", LastName="Last", PhoneNumber="3" },
        };

        //public static List<Employee> GetEmployees() => _employees;

        public static List<Employee> GetEmployees()
        {
            return _database.Table<Employee>().ToList();
        }

        public static Employee GetEmployeeById(int id)
        {
            //var employee = _employees.FirstOrDefault(x => x.EmployeeId == id);

            //if (employee != null)
            //{
            //    return new Employee 
            //    { 
            //        EmployeeId = employee.EmployeeId,
            //        FirstName = employee.FirstName,
            //        LastName = employee.LastName,
            //        PhoneNumber = employee.PhoneNumber,
            //    };
            //}

            //return null;

            return _database.Table<Employee>().FirstOrDefault(employee => employee.EmployeeId == id);
        }

        //public static void UpdateEmployee(int employeeId, Employee employee)
        public static void UpdateEmployee(Employee employee)
        {
            //if (employeeId != employee.EmployeeId) return;

            //var employeeToUpdate = _employees.FirstOrDefault(x => x.EmployeeId == employeeId);

            //if (employeeToUpdate != null)
            //{
            //    employeeToUpdate.FirstName = employee.FirstName;
            //    employeeToUpdate.LastName = employee.LastName;
            //    employeeToUpdate.PhoneNumber = employee.PhoneNumber;
            //}

            _database.Update(employee);
        }

        public static void AddEmployee(Employee employee)
        { 
            //var maxId = _employees.Max(x => x.EmployeeId);
            //employee.EmployeeId = maxId + 1;
            //_employees.Add(employee);

            _database.Insert(employee);
        }

        public static void DeleteEmployee(int employeeId)
        {
            //var employee = _employees.FirstOrDefault(x => x.EmployeeId == employeeId);
            //if (employee != null)
            //{
            //    _employees.Remove(employee);
            //}
            _database.Delete<Employee>(employeeId);
        }
    }
}
