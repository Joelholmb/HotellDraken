using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;

namespace hotelcsharp
{
    public class EmployeeList
    {

        private List<Employee> employees;

        public void Login()
        {
            employees = new List<Employee>
            {
                new Employee("liam@myhotel.com", "admin123"),
                new Employee("william@myhotel.com","admin000"),
                new Employee("camilla@myhotel.com","admin999"),
            };

            bool Authenticate(string username, string password)
            {
                Employee employee = employees.Find(emp => emp.Username == username && emp.Password == password);
                return employee != null; 
            }
        }
    }  
}
