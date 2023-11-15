namespace hotelcsharp
{
    public class BookRoom
    {
        // Huvudmetod för att hantera rum-bokningsprocessen
        public void MakeBooking()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Tillgängliga rum:");
            Console.ResetColor();

            // Visar en lista över tillgängliga rum
            RoomList.ListAvailableRooms();

            // Få användarens val av rum
            int roomIndex = GetRoomChoice();
            if (roomIndex == 0) 
            {
                Console.WriteLine("Bokning avbruten.");
                return;
            }

            // Visar information om det valda rummet
            RoomList.ShowInfoRoom(roomIndex);

            // Begär bekräftelse från användaren innan bokningen fortsätter
            if (GetUserConfirmation())
            {
                // Hanterar bokningsprocessen baserat på användarens val
                ProcessBooking(roomIndex);
            }
        }

        // Metod för att få användarens rumval
        private int GetRoomChoice()
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
        private bool GetUserConfirmation()
        {
            Console.Write("\nVill du boka detta rum? (ja/nej): ");
            return Console.ReadLine().Equals("ja", StringComparison.OrdinalIgnoreCase);
        }

        // Metod för att hantera bokningen av ett rum
        private void ProcessBooking(int roomIndex)
        {
            // Hämta tillgängliga bokningsintervall för rummet
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
        private int GetIntervalChoice(int count)
        {
            int intervalChoice;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out intervalChoice) && intervalChoice >= 1 && intervalChoice <= count)
                {
                    return intervalChoice;
                }
            } 
        }
    }
}
