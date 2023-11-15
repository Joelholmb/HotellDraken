namespace hotelcsharp
{
    public class RoomList
    {
        public List<Rooms> rooms { get; private set; }
        //Denna konstruktion används för att skydda data. Även om andra delar av programmet kan se vilka rum som finns, kan de inte ändra listan av rum direkt. 
        public RoomList() 
        {
            rooms = new List<Rooms>
            {
                //Fördefinerade rum som läggs till i listan.
                new Rooms("Lancelot", "Superior-rum", "2 enkelsängar", "26 kvadratmeter", "en betongvägg", "3700 kr"),
                new Rooms("Merlin", "Premium-rum", "1 queen-size säng", "36 kvadratmeter", "staden", "5000 kr"),
                new Rooms("Arthur", "Svit", "1 kingsize-säng", "49 kvadratmeter", "havet", "12000 kr"),
            };
        }
        // Listar alla tillgängliga rum som inte är bokade
        public void ListAvailableRooms()
        {
            int index = 1;
            foreach (var currentRoom in rooms)
            {
                // Kontrollerar om rummet inte är bokat och skriver ut information
                if (currentRoom.IsBooked == false)
                {
                    Console.WriteLine($"{index}. {currentRoom.RoomName}, {currentRoom.RoomType}. Pris för en natt {currentRoom.RoomPrice}.");
                }
                index++;
            }
        }
        // Bokar ett specifikt rum baserat på indexet i listan
        public void BookRoom(int roomIndex)
        {
            // Kontrollerar att rumindexet är inom giltiga gränser
            if (roomIndex > 0 && roomIndex <= rooms.Count)
            {
                Rooms roomToBook = rooms[roomIndex - 1];
                 // Kontrollerar om rummet inte redan är bokat
                if (roomToBook.IsBooked == false)
                {
                    roomToBook.Book();
                }
                else
                {
                    Console.WriteLine("Rummet är redan bokat.");
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt val eller rummet är inte tillgängligt för bokning.");
            }
        }
        // Visar information om ett specifikt rum baserat på index
        public void ShowInfoRoom(int roomIndex)
        {
            if (roomIndex > 0 && roomIndex <= rooms.Count)
            {
                var selectedRoom = rooms[roomIndex - 1];
                 // Skriver ut detaljer om rummet
                Console.WriteLine($"\nInformation för rummet {selectedRoom.RoomName}:");
                Console.WriteLine($"{selectedRoom.RoomType}");
                Console.WriteLine($"{selectedRoom.RoomSize}");
                Console.WriteLine($"{selectedRoom.TypeBed}");
                Console.WriteLine($"Utsikt över {selectedRoom.RoomView}");
                Console.WriteLine($"Pris per natt: {selectedRoom.RoomPrice}");
            }
            else
            {
                Console.WriteLine("Ogiltigt rumindex.");
            }
        }

        public void ListBookedRooms()
        {
            Console.WriteLine("Bokade rum:");
            foreach (var currentRoom in rooms)
            {
                // Kontrollerar om rummet är bokat och visar bokningsinformation
                if (currentRoom.IsBooked)
                {
                    Console.WriteLine($"Bokningsnr: {currentRoom.BookingNumber} - {currentRoom.RoomName}");
                }
            }
        }

        public bool CancelRoomBooking(int bookingNumber)
        {
            foreach (var currentRoom in rooms)
            {
                if (currentRoom.BookingNumber == bookingNumber && currentRoom.IsBooked)
                {
                    currentRoom.CancelBooking();
                    return true;
                }
            }
            return false;
        }
    }
}
