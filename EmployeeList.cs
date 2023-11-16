using System.Reflection.Metadata.Ecma335;

namespace hotelcsharp
{
    public class EmployeeList // Definera en class som heter EmployeeList
    {
        List<Employee> employees = new List<Employee> //Skapa en lista för att lagra Employee-objekt
        {
            //Initiera listan med några hårdkodade Employee-instanser
            new Employee("liam@myhotel.com", "admin123"),
            new Employee("william@myhotel.com","admin000"),
            new Employee("camilla@myhotel.com","admin999"),
        };
    }
}
