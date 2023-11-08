
namespace hotelcsharp
{
    public class GuestList
    {
        public static List<Guest> guests = new List<Guest>
        {
        new Guest("Alfons", "Glassgatan 12", "0733111111", "inget@harjag.com"),
        new Guest("Laban", "Melonvägen 5", "07332222222", "ett@jaghar.com"),
        new Guest("Professor Baltazar", "Rödferrarigatan 45", "0733333333", "jaghartroligtvisett@trottsallt.com"),
        };
        public void PrintGuestList()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Här är Gästlistan för hotell Draken.\n");
            Console.ResetColor();
            
            
            foreach (Guest guest in guests)
            {
                
                Console.WriteLine($" Namn: {guest.Name}. Adress: {guest.Adress}. Mobilnr: {guest.PhoneNumber}. Epostadress: {guest.Email}.");
                
            }
            
        }
      
        

    }


}