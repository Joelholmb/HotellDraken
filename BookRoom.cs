namespace hotelcsharp
{
    public static class BookRoom
    {
        // Huvudmetod för att hantera rum-bokningsprocessen
        public static void MakeBooking()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Tillgängliga rum:");
            Console.ResetColor();

            RoomList.ListAvailableRooms();
            // Få användarens val av rum
            int roomIndex = GetRoomChoice();

            if (roomIndex == 0) 
            {
                Console.WriteLine("Bokning avbruten.");
            }
            else
            {
                Console.Clear();
                RoomList.ShowInfoRoom(roomIndex);
                // Begär bekräftelse från användaren innan bokningen fortsätter
                if (GetUserConfirmation())
                {
                    // Hanterar bokningsprocessen baserat på användarens val
                    ProcessBooking(roomIndex);
                }
            }
        }
        // Metod för att få användarens rumval
        private static int GetRoomChoice()
        {
            while (true)
            {
                Console.WriteLine("\nAnge numret på det rum du vill boka [1-3] eller 0 för att avbryta:");
                if (int.TryParse(Console.ReadLine(), out int roomIndex) && 
                    (roomIndex == 0 || (roomIndex > 0 && roomIndex <= RoomList.rooms.Count)))
                {
                    return roomIndex;
                }
                Console.WriteLine("Ogiltigt val. Försök igen.");
            }
        }
        // Metod för att bekräfta användarens val
        private static bool GetUserConfirmation()
        {
            Console.Write("\nVill du boka detta rum? (ja/nej): ");
            return Console.ReadLine().Equals("ja", StringComparison.OrdinalIgnoreCase);
        }
        // Metod för att hantera bokningen av ett rum
        private static void ProcessBooking(int roomIndex)
        {
            // Hämta tillgängliga bokningsintervall för rummet
            Console.Clear();
            var availableIntervals = RoomList.GetAvailableWeekIntervals(roomIndex, 4);
            Console.WriteLine("\nVälj ett bokningsintervall från följande tillgängliga tider:");
            for (int i = 0; i < availableIntervals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableIntervals[i].Item1.ToShortDateString()} till {availableIntervals[i].Item2.ToShortDateString()}");
            }
            // Få användarens val av bokningsintervall
            int intervalChoice = GetIntervalChoice(availableIntervals.Count);
            var chosenInterval = availableIntervals[intervalChoice - 1];
            // Försök att boka rummet och meddela användaren om utfallet
            if (RoomList.BookRoom(roomIndex, chosenInterval.Item1, chosenInterval.Item2))
            {
                Console.WriteLine($"Rum {RoomList.rooms[roomIndex - 1].RoomName} bokat från {chosenInterval.Item1.ToShortDateString()} till {chosenInterval.Item2.ToShortDateString()}.");
            }
            else
            {
                Console.WriteLine("Bokningen kunde inte genomföras.");
            }
        }
        // Metod för att få användarens val av bokningsintervall
        private static int GetIntervalChoice(int count)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int intervalChoice) && intervalChoice >= 1 && intervalChoice <= count)
                {
                    return intervalChoice;
                }
            } 
        }
    }
}
