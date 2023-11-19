namespace hotelcsharp
{
    public static class HotelManagement
    {
        // Metod för att låta användaren välja en gästprofil
        public static void ChooseGuestProfile()
        {
            Console.Clear();
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
                Console.Clear();
                Guest chosenGuest = GuestList.guests[selectedGuestIndex - 1];
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Välkommen {chosenGuest.Name}.");
                Console.ResetColor();
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Felaktig inmatning. Välj ett nummer från listan.");
                Console.ResetColor();
            }
        }

            // Metod för att logga in anställda och visa anställdas meny
        public static void LoginEmployee()
        {
            Console.Clear();
            Console.WriteLine("Ange ditt användarnamn!");
            string username = Console.ReadLine();

            Console.WriteLine("Ange ditt lösenord!");
            string password = Console.ReadLine();

            if (EmployeeList.Authenticate(username, password))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Inloggningen lyckades, välkommen tillbaka {username}");
                Console.ResetColor();

                // Lägg till en paus för att låta användaren se inloggningsmeddelandet
                Console.WriteLine("\nTryck på valfri tangent för att fortsätta till menyn...");
                Console.ReadKey();

                MenuEmployee.ShowEmployeeMenu();  // Visa anställdas meny
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Inloggningen misslyckades, försök igen.");
                Console.ResetColor();
            }
        }
    }
}

