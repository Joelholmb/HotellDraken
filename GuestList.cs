namespace hotelcsharp
{
    public class GuestList
    {
        public List<Guest> guests = new List<Guest>
        {
        new Guest("Alfons", "Glassgatan 12", "0733111111", "inget@harjag.com"),
        new Guest("Laban", "Melonvägen 5", "07332222222", "ett@jaghar.com"),
        new Guest("Herr Baltazar", "Rödferrariegatan 45", "0733333333", "jaghartroligtvisett@trottsallt.com"),
        };
        public void PrintGuestList()
        {
            Console.WriteLine(" Här är Gästlistan för hotell Draken.\n");
            foreach (Guest guest in guests)
            {
                Console.Write($" Namn: {guest.Name}");
                Console.Write($" Adress: {guest.Adress}");
                Console.Write($" Mobilnr: {guest.PhoneNumber}");
                Console.Write($" Epostadress: {guest.Email}");
                Console.WriteLine();
            }
            
        }
      
        

    }


}