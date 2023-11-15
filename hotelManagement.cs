namespace hotelcsharp
{

    public class HotelManagement
    {
        private RoomList roomList;
        public HotelManagement(RoomList roomList)
    {
        this.roomList = roomList;
    }
        // En strängvariabel för att lagra användarens roll (gäst eller anställd)
        public string userRole;

        // Metoden ChooseRole låter användaren välja sin roll i systemet
        public void ChooseRole()
        {
            Console.WriteLine("Är du en gäst eller en anställd? (G/A)");
            string input = Console.ReadLine();

            // Kontrollerar om användaren angav att de är en gäst
            if (input.Equals("G", StringComparison.OrdinalIgnoreCase))
            {
                userRole = "Gäst";
                ManageGuest();
                ShowGuestMenu();
            }
            // Kontrollerar om användaren angav att de är en anställd
            else if (input.Equals("A", StringComparison.OrdinalIgnoreCase))
            {
                userRole = "Anställd";
                ManageEmployee();
                ShowEmployeeMenu();
            }
            else
            {
                Console.WriteLine("Felaktig inmatning. Välj antingen G eller A.");
                ChooseRole();
            }
        }
        // Visar menyn för gäster när man väljer G.
        private void ShowGuestMenu()
        {
            Menu guestMenu = new Menu(roomList);
            guestMenu.ShowGuestMenu();
            
        }
        //Låter en logga in med en gästprofil
        private void ManageGuest()
        {
            Console.WriteLine("Välj vilken profil du vill logga in med:");
            // Visar en lista över alla gäster
            for (int i = 0; i < GuestList.guests.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {GuestList.guests[i]}");
            }
            
             // Läser in användarens val och kontrollerar om det är ett giltigt index
            if (int.TryParse(Console.ReadLine(), out int selectedGuestIndex))
            {
                // Justerar indexet till 1 då det börjar från 0 annars.
                selectedGuestIndex -= 1;
                // Kontrollerar att det valda indexet är inom giltiga gränser
                if (selectedGuestIndex >= 0 && selectedGuestIndex < GuestList.guests.Count)
                {
                    Guest chosenGuest = GuestList.guests[selectedGuestIndex];
                    Console.WriteLine($"Välkommen {chosenGuest.Name}. Vad vill du göra?");
                    
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning. Välj ett nummer från listan.");
                    ManageGuest();
                }
            }
  
        }

        private void ShowEmployeeMenu()
        {
            MenuEmployee employeeMenu = new MenuEmployee(roomList);
            employeeMenu.ShowEmployeeMenu();
            
        }


        private void ManageEmployee()
        {
            
            Console.WriteLine("Välkommen tillbaka, kollega!");
            
        }
    }
}