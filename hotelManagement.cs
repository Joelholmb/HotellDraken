namespace hotelcsharp
{
    public static class HotelManagement
    {
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
    }
}
