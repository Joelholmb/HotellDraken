namespace hotelcsharp
{
    public static class RoomList
    {
        public static List<Rooms> rooms = new List<Rooms>();

        static RoomList() 
        {
            // Initialisera rummen med förinställda värden
            rooms = new List<Rooms>
            {
                new Rooms("Lancelot", "Superior-rum", "2 enkelsängar", "26 kvadratmeter", "en betongvägg", "3700 kr"),
                new Rooms("Merlin", "Premium-rum", "1 queen-size säng", "36 kvadratmeter", "staden", "5000 kr"),
                new Rooms("Arthur", "Svit", "1 kingsize-säng", "49 kvadratmeter", "havet", "12000 kr"),
            };
        }

        public static void ListAvailableRooms()
        {
            // Visa tillgängliga rum
            int index = 1;
            foreach (var room in rooms)
            {
                if (room.IsBooked == false)
                {
                    Console.WriteLine($"{index}. {room.RoomName}, {room.RoomType}. Pris för en natt {room.RoomPrice}.");
                    index++;
                }
            }
        }

        public static void ShowInfoRoom(int roomIndex)
        {
            // Visa information om ett specifikt rum baserat på index
            if (roomIndex > 0 && roomIndex <= rooms.Count)
            {
                var selectedRoom = rooms[roomIndex - 1];
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nInformation för rummet {selectedRoom.RoomName}:");
                Console.ResetColor();
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
            // Boka ett rum om det är tillgängligt under önskad period
            bool bookingSuccess = false;
            if (roomIndex > 0 && roomIndex <= rooms.Count)
            {
                Rooms roomToBook = rooms[roomIndex - 1];
                bool isOverlap = false;

                // Kontrollera om datumet krockar med befintliga bokningar
                int i = 0;
                while (i < roomToBook.BookedPeriods.Count && !isOverlap)
                {
                    var period = roomToBook.BookedPeriods[i];
                    if (startDate < period.end && endDate > period.start)
                    {
                        isOverlap = true;
                    }
                    i++;
                }

                // Utför bokningen om det inte finns någon överlappning
                if (isOverlap == false)
                {
                    roomToBook.Book(startDate, endDate);
                    bookingSuccess = true;
                }
            }
            return bookingSuccess;
        }

        public static List<(DateTime start, DateTime end)> GetAvailableWeekIntervals(int roomIndex, int numberOfWeeks)
        {
            // Hämta tillgängliga veckointervall för ett rum
            List<(DateTime start, DateTime end)> availableIntervals = new List<(DateTime start, DateTime end)>();
            if (roomIndex > 0 && roomIndex <= rooms.Count)
            {
                var room = rooms[roomIndex - 1];
                DateTime currentDate = DateTime.Today;

                // Iterera över antal veckor för att hitta lediga intervall
                int week = 0;
                while (week < numberOfWeeks)
                {
                    var weekStart = currentDate.AddDays(week * 7);
                    var weekEnd = weekStart.AddDays(7);
                    bool isOverlap = false;

                    // Kontrollera varje bokad period för att se om det finns en överlappning
                    int i = 0;
                    while (i < room.BookedPeriods.Count && isOverlap == false)
                    {
                        var period = room.BookedPeriods[i];
                        if (weekStart < period.end && weekEnd > period.start)
                        {
                            isOverlap = true;
                        }
                        i++;
                    }

                    // Lägg till intervallet i listan om det inte finns någon överlappning
                    if (isOverlap == false)
                    {
                        availableIntervals.Add((weekStart, weekEnd));
                    }
                    week++;
                }
            }

            return availableIntervals;
        }

        public static void ListBookedRooms()
        {
            // Visa en lista över alla bokade rum
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
            // Avboka ett rum baserat på bokningsnummer
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
