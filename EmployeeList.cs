namespace hotelcsharp
{
    public class EmployeeList
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee("liam", "admin123"),
            new Employee("william", "admin000"),
            new Employee("camilla", "admin999"),
        };

        public static bool Authenticate(string username, string password)
        {
            Employee employee = employees.Find(emp => emp.Username == username && emp.Password == password);
            return employee != null;
        }
    }
}
