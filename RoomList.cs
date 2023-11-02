
namespace hotelcsharp
{
    public class RoomList
    {
        public List<Rooms> room = new List<Rooms>
        {
        new Rooms("Lancelot", "Enkelrum", 13, "3700kr"),
        new Rooms("Merlin", "Dubbelrum",22, "5000kr"),
        new Rooms("Arthur", "Svit", 1, "12000kr"),
        };
        public void PrintRoomList()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Tillgängliga rum för hotell Draken.\n");
            Console.ResetColor();
            
            
            foreach (Rooms rooms in room)
            {
                
                Console.WriteLine($" Rumsnamn: {rooms.RoomName}. Rumstyp: {rooms.RoomType}. Rumsnr: {rooms.RoomNumber}.\n Pris per natt: {rooms.RoomPrice}");
                
            }
            
        }
      
        

    }


}