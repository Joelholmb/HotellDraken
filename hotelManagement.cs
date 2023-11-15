namespace hotelcsharp
{
    public class HotelManagement
    {
        private MenuEmployee menuEmployee;
        private Menu menuGuest;

        public HotelManagement()
        {
            menuEmployee = new MenuEmployee();
            menuGuest = new Menu();
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("Är du en gäst eller en anställd? (G/A)\nTryck på 'Q' för att avsluta.");
                string input = Console.ReadLine()?.ToUpper() ?? "";

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

        private void ChooseGuestProfile()
        {
            Console.WriteLine("Välj vilken gästprofil du vill logga in med:");
            for (int i = 0; i < GuestList.guests.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {GuestList.guests[i].Name}");
            }

            int selectedGuestIndex;
            if (int.TryParse(Console.ReadLine(), out selectedGuestIndex) &&
                selectedGuestIndex > 0 && selectedGuestIndex <= GuestList.guests.Count)
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
