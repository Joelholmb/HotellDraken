namespace hotelcsharp
{
    public class RoomList
    {
        private static RoomList instance;
        public List<Rooms> rooms { get; private set; }
        private RoomList() 
        {
            rooms = new List<Rooms>
            {
                new Rooms("Lancelot", "Superior-rum", "2 enkelsängar", "26 kvadratmeter", "en betongvägg", "3700 kr"),
                new Rooms("Merlin", "Premium-rum", "1 queen-size säng", "36 kvadratmeter", "staden", "5000 kr"),
                new Rooms("Arthur", "Svit", "1 kingsize-säng", "49 kvadratmeter", "havet", "12000 kr"),
            };
        }

        public static RoomList GetInstance()
        {
            if (instance == null)
            {
                instance = new RoomList();
            }
            return instance;
        }
        
        public void ListAvailableRooms()
        {
            int index = 1;
            foreach (var currentRoom in rooms)
            {
                if (currentRoom.IsBooked == false)
                {
                    Console.WriteLine($"{index}. {currentRoom.RoomName}, {currentRoom.RoomType}. Pris för en natt {currentRoom.RoomPrice}.");
                }
                index++;
            }
        }

        public void BookRoom(int roomIndex)
        {
            if (roomIndex > 0 && roomIndex <= rooms.Count)
            {
                Rooms roomToBook = rooms[roomIndex - 1];
                if (!roomToBook.IsBooked)
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

        public void ShowInfoRoom(int roomIndex)
        {
            if (roomIndex > 0 && roomIndex <= rooms.Count)
            {
                var selectedRoom = rooms[roomIndex - 1];
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
