namespace hotelcsharp
{
    public static class RoomList
    {
        public static List<Rooms> rooms = new List<Rooms>();

        static RoomList() 
        {
            // Fördefinerade rum som läggs till i listan
            rooms = new List<Rooms>
            {
                new Rooms("Lancelot", "Superior-rum", "2 enkelsängar", "26 kvadratmeter", "en betongvägg", "3700 kr"),
                new Rooms("Merlin", "Premium-rum", "1 queen-size säng", "36 kvadratmeter", "staden", "5000 kr"),
                new Rooms("Arthur", "Svit", "1 kingsize-säng", "49 kvadratmeter", "havet", "12000 kr"),
            };
        }

        public static void ListAvailableRooms()
        {
            int index = 1;
            foreach (var room in rooms)
            {
                if (!room.IsBooked)
                {
                    Console.WriteLine($"{index}. {room.RoomName}, {room.RoomType}. Pris för en natt {room.RoomPrice}.");
                    index++;
                }
            }
        }

        public static void ShowInfoRoom(int roomIndex)
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

        public static bool BookRoom(int roomIndex, DateTime startDate, DateTime endDate)
        {
            if (roomIndex > 0 && roomIndex <= rooms.Count)
            {
                Rooms roomToBook = rooms[roomIndex - 1];
                if (!roomToBook.BookedPeriods.Any(p => startDate < p.end && endDate > p.start))
                {
                    roomToBook.Book(startDate, endDate);
                    return true; // Returnera sant för att indikera att bokningen lyckades
                }
            }
            return false; // Returnera falskt om bokningen inte går att genomföra
        }

        public static List<(DateTime start, DateTime end)> GetAvailableWeekIntervals(int roomIndex, int numberOfWeeks)
        {
            List<(DateTime start, DateTime end)> availableIntervals = new List<(DateTime start, DateTime end)>();
            DateTime currentDate = DateTime.Today;
            var room = rooms[roomIndex - 1];

            for (int i = 0; i < numberOfWeeks; i++)
            {
                var weekStart = currentDate.AddDays(i * 7);
                var weekEnd = weekStart.AddDays(7);

                if (!room.BookedPeriods.Any(p => weekStart < p.end && weekEnd > p.start))
                {
                    availableIntervals.Add((weekStart, weekEnd));
                }
            }

            return availableIntervals;
        }

        public static void ListBookedRooms()
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

        public static bool CancelRoomBooking(int bookingNumber)
        {
            foreach (var room in rooms)
            {
                if (room.BookingNumber == bookingNumber && room.IsBooked)
                {
                    room.CancelBooking();
                    return true; // Bokningen har avbokats korrekt
                }
            }
            return false; // Ingen bokning hittades med detta bokningsnummer
        }
    }
}
