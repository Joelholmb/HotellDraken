namespace hotelcsharp
{
    public class Employee // Definiera en klass som heter Employee
    {
        // Public properties för att lagra användarnamn och lösenord för en anställd
        public string Username { get; set; }
        public string Password { get; set; }

        // Konstruktör för att initiera Employee-objektet med ett användarnamn och lösenord
        public Employee(string username, string password)
        {
            Username = username; //Ställ in egenskapen Användarnamn med det angivna användarnamnet
            Password = password; //Ställ in lösenordsegenskapen med det angivna lösenordet
        }
    }

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