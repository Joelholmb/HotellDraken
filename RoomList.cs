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
                if (!currentRoom.IsBooked)
                {
                    Console.WriteLine($"{index}. {currentRoom.RoomName}, {currentRoom.RoomType}. Pris för en natt {currentRoom.RoomPrice}.");
                    index++;
                }
            }
        }

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

        public void BookRoom(int roomIndex)
        {
            if (roomIndex > 0 && roomIndex <= rooms.Count)
            {
                Rooms roomToBook = rooms[roomIndex - 1];

                var availableIntervals = GetAvailableWeekIntervals(roomIndex, 4); // Exempel: nästa 4 veckor

                Console.WriteLine("Välj ett bokningsintervall från följande tillgängliga tider:");
                for (int i = 0; i < availableIntervals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {availableIntervals[i].Item1.ToShortDateString()} till {availableIntervals[i].Item2.ToShortDateString()}");
                }

                Console.WriteLine("Välj ett intervall genom att ange numret:");
                int intervalChoice;
                while (!int.TryParse(Console.ReadLine(), out intervalChoice) || intervalChoice < 1 || intervalChoice > availableIntervals.Count)
                {
                    Console.WriteLine("Ogiltigt val, försök igen:");
                }

                var chosenInterval = availableIntervals[intervalChoice - 1];
                roomToBook.Book(chosenInterval.Item1, chosenInterval.Item2);
            }
            else
            {
                Console.WriteLine("Ogiltigt val eller rummet är inte tillgängligt för bokning.");
            }
        }

        private List<(DateTime, DateTime)> GetAvailableWeekIntervals(int roomIndex, int numberOfWeeks)
        {
            List<(DateTime, DateTime)> availableIntervals = new List<(DateTime, DateTime)>();
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
