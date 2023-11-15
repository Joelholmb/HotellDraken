namespace hotelcsharp
{
    public class HotelManagement
    {
        private MenuEmployee menuEmployee;
        private Menu menuGuest;

        // Konstruktor för att initiera menyer för anställda och gäster
        public HotelManagement()
        {
            menuEmployee = new MenuEmployee();
            menuGuest = new Menu();
        }

        // Startmetoden som kör huvudmenyn för programmet
        public void Start()
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
                        menuGuest.ShowGuestMenu();
                        break;
                    case "A":
                        menuEmployee.ShowEmployeeMenu();
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
        private void ChooseGuestProfile()
        {
            Console.WriteLine("Välj vilken gästprofil du vill logga in med:");
            for (int i = 0; i < GuestList.guests.Count; i++)
            {
                // Visar en lista över tillgängliga gästprofiler
                Console.WriteLine($"{i + 1}. {GuestList.guests[i].Name}");
            }

            // Låter användaren välja en profil baserat på listnumret
            int selectedGuestIndex = Convert.ToInt32(Console.ReadLine());

            // Validerar valet och hälsar den valda gästen välkommen!
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
    }
}
