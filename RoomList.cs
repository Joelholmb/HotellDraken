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
                new Rooms(1,"Lancelot", "Superior-rum", "2 enkelsängar", "26 kvadratmeter", "en betongvägg", "3700 kr"),
                new Rooms(2,"Merlin", "Premium-rum", "1 queen-size säng", "36 kvadratmeter", "staden", "5000 kr"),
                new Rooms(3,"Arthur", "Svit", "1 kingsize-säng", "49 kvadratmeter", "havet", "12000 kr"),
            };
        }

        public static void ListAvailableRooms()
        {
            foreach (var room in rooms)
            {
                if (room.IsBooked == false)
                {
                    Console.WriteLine($"{room.RoomId}. {room.RoomName}, {room.RoomType}. Pris för en natt {room.RoomPrice}.");
                }
            }
        }

        public static void ShowInfoRoom(int roomIndex)
        {
            // Visa information om ett specifikt rum baserat på index
            Console.Clear();
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

       public static bool BookRoom(int roomId, DateTime startDate, DateTime endDate)
        {
            bool roomFound = false;  // Flagga för att indikera om ett passande rum hittats

            // Iterera över listan för att hitta rummet med det angivna RoomId
            foreach (var room in rooms)
            {
                if (room.RoomId == roomId)
                {
                    if (room.IsBooked == false)  // Kontrollera om rummet inte är bokat
                    {
                        room.Book();
                        roomFound = true; // Uppdatera flaggan till true när man bokat rummet
                        break;
                    }
                }
            }

            return roomFound; // Returnera om ett rum hittades och bokades
        }


        public static List<(DateTime start, DateTime end)> GetAvailableWeekIntervals(int roomId, int numberOfWeeks)
        {
            var availableIntervals = new List<(DateTime start, DateTime end)>();

            foreach (var room in rooms)
            {
                if (room.RoomId == roomId && room.IsBooked == false)
                {
                    DateTime currentDate = DateTime.Today;

                    for (int week = 0; week < numberOfWeeks; week++)
                    {
                        var weekStart = currentDate.AddDays(week * 7);
                        var weekEnd = weekStart.AddDays(7);
                        availableIntervals.Add((weekStart, weekEnd));
                    }
                    break;
                }
            }

            return availableIntervals;
        }




        public static void ListBookedRooms()
        {
            Console.WriteLine("Bokade rum:");
            bool bookedRoomFound = false;

            foreach (var currentRoom in rooms)
            {
                if (currentRoom.IsBooked)
                {
                    Console.WriteLine($"Bokningsnr: {currentRoom.BookingNumber} - {currentRoom.RoomName}");
                    bookedRoomFound = true;
                }
            }

            if (bookedRoomFound == false)
            {
                Console.WriteLine("Det finns inga aktiva bokningar för närvarande.");
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
