namespace hotelcsharp
{
    public static class BookRoom
    {
        public static void MakeBooking()
        {
            Console.Clear();
            RoomList.ListAvailableRooms();
            int roomId = GetRoomChoice();

            if (roomId != 0)
            {
                BookSelectedRoom(roomId);
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bokning avbruten.");
                Console.ResetColor();
            }
        }

        private static int GetRoomChoice()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nAnge numret på det rum du vill boka eller 0 för att avbryta:");
            Console.ResetColor();
            int.TryParse(Console.ReadLine(), out int roomId);
            return roomId;
        }

        private static void BookSelectedRoom(int roomId)
        {
            Console.Clear();
            RoomList.ShowInfoRoom(roomId);

            if (!GetUserConfirmation())
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bokningen avbruten.");
                Console.ResetColor();
                return;
            }

            var availableIntervals = RoomList.GetAvailableWeekIntervals(roomId, 4);
            if (availableIntervals.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Inga tillgängliga tidsintervall för detta rum.");
                Console.ResetColor();
                return;
            }

            Console.Clear();
            ShowAvailableIntervals(availableIntervals);
            int intervalChoice = GetIntervalChoice(availableIntervals);

            if (intervalChoice == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bokningen avbruten.");
                Console.ResetColor();
                return;
            }

            var chosenInterval = availableIntervals[intervalChoice - 1];
            if (RoomList.BookRoom(roomId, chosenInterval.start, chosenInterval.end))
            {
               
                Console.WriteLine(" ");
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Det gick inte att boka rummet.");
                Console.ResetColor();
            }
        }

        private static void ShowAvailableIntervals(List<(DateTime start, DateTime end)> intervals)
        {   
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nTillgängliga tidsintervaller:");
            Console.ResetColor();
            for (int i = 0; i < intervals.Count; i++)
            {
                var interval = intervals[i];
                Console.WriteLine($"{i + 1}. Från {interval.start.ToShortDateString()} till {interval.end.ToShortDateString()}");
            }
        }

        private static int GetIntervalChoice(List<(DateTime start, DateTime end)> intervals)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nAnge numret på det tidsintervall du vill boka eller 0 för att avbryta:");
            Console.ResetColor();
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 0) 
                    {
                        return 0;
                    }
                    else if (choice > 0 && choice <= intervals.Count)
                    {
                        return choice;
                    }
                }

                Console.WriteLine($"Ogiltigt val. Ange ett nummer mellan 1 och {intervals.Count}, eller 0 för att avbryta:");
            }
        }

        private static bool GetUserConfirmation()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nVill du boka detta rum? (ja/nej): ");
            Console.ResetColor();
            return Console.ReadLine().Trim().Equals("ja", StringComparison.OrdinalIgnoreCase);
        }
    }
}
