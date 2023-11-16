
namespace hotelcsharp
{
    public static class HotelManagement
    {
       
        // Startmetoden som kör huvudmenyn för programmet
        public static void Start()
        {
            while (true)
            {
                Console.WriteLine("\nÄr du en gäst eller en anställd? (G/A)\nTryck på 'Q' för att avsluta.");
                string input = Console.ReadLine()?.ToUpper() ?? "";

                // Hanterar användarens val och navigerar till rätt meny
                switch (input)
                {
                    case "G":
                        ChooseGuestProfile();
                        Menu.ShowGuestMenu();
                        break;
                    case "A":
                        MenuEmployee.ShowEmployeeMenu();
                        break;
                    case "Q":
                        Console.WriteLine("Avslutar programmet...");
                        return;
                    default:
                        Console.WriteLine("Felaktig inmatning. Välj antingen G, A eller Q.");
                        break;
                }
            }
        }

        // Metod för att låta användaren välja en gästprofil
        public static void ChooseGuestProfile()
        {
            Console.WriteLine("Välj vilken gästprofil du vill logga in med:");
            for (int i = 0; i < GuestList.guests.Count; i++)
            {
                // Visar en lista över tillgängliga gästprofiler
                Console.WriteLine($"{i + 1}. {GuestList.guests[i].Name}");
            }

            // Låter användaren välja en profil baserat på listnumret
            int selectedGuestIndex = Convert.ToInt32(Console.ReadLine());

            // Validerar valet och hälsar den valda gästen
            if (selectedGuestIndex > 0 && selectedGuestIndex <= GuestList.guests.Count)
            {
                Guest chosenGuest = GuestList.guests[selectedGuestIndex - 1];
                Console.WriteLine($"Välkommen {chosenGuest.Name}.");
            }
            else
            {
                Console.WriteLine("Felaktig inmatning. Välj ett nummer från listan.");
            }
        }

        public static class EmployeeList
        {

            private static List<Employee> employees;

            static EmployeeList()
            {
                employees = new List<Employee>
                {
                    new Employee("liam@myhotel.com", "admin123"),
                    new Employee("william@myhotel.com","admin000"),
                    new Employee("camilla@myhotel.com","admin999"),
                };
            }
            public static bool Authenticate(string username, string password)
            {
                Employee employee = employees.Find(emp => emp.Username == username && emp.Password == password);
                return employee != null;
            }
            
    
            public static void Login()
            {
                Console.WriteLine("Ange ditt användarnamn!");
                string username = Console.ReadLine();

                Console.WriteLine("Ange ditt läsenord!");
                string password = Console.ReadLine();

                if (Authenticate(username, password))
                {
                    Console.WriteLine($"Inloggningen lyckades, välkommen tillbaka {username}");
                } 
                else
                {
                    Console.WriteLine("Inloggningen misslyckades, försök igen senare");
                }
            }
        }
    }
}

