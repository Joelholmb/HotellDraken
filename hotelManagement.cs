namespace hotelcsharp
{

    public class HotelManagement
    {
        public string userRole;

        public void ChooseRole()
        {
            Console.WriteLine("Är du en gäst eller en anställd? (G/A)");
            string input = Console.ReadLine();

            if (input.Equals("G", StringComparison.OrdinalIgnoreCase))
            {
                userRole = "Gäst";
                ManageGuest();
                ShowGuestMenu();
            }
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
        private void ShowGuestMenu()
        {
            Menu guestMenu = new Menu();
            guestMenu.ShowGuestMenu();
            
        }

        private void ManageGuest()
        {
            Console.WriteLine("Välj vilken profil du vill logga in med:");
            for (int i = 0; i < GuestList.guests.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {GuestList.guests[i]}");
            }

            if (int.TryParse(Console.ReadLine(), out int selectedGuestIndex))
            {
                selectedGuestIndex -= 1;
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
            MenuEmployee employeeMenu = new MenuEmployee();
            employeeMenu.ShowEmployeeMenu();
            
        }


        private void ManageEmployee()
        {
            
            Console.WriteLine("Välkommen tillbaka, kollega!");
            
        }
    }
}