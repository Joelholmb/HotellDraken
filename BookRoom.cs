namespace hotelcsharp
{
    public class BookRoom
    {
        public void MakeBooking()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Tillgängliga rum:");
            Console.ResetColor();

            RoomList.ListAvailableRooms();

            int roomIndex = GetRoomChoice();
            if (roomIndex == 0) 
            {
                Console.WriteLine("Bokning avbruten.");
                return;
            }

            RoomList.ShowInfoRoom(roomIndex);
            if (GetUserConfirmation())
            {
                ProcessBooking(roomIndex);
            }
        }

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

        private bool GetUserConfirmation()
        {
            Console.Write("\nVill du boka detta rum? (ja/nej): ");
            return Console.ReadLine().Equals("ja", StringComparison.OrdinalIgnoreCase);
        }

        private void ProcessBooking(int roomIndex)
        {
            var availableIntervals = RoomList.GetAvailableWeekIntervals(roomIndex, 4);
            Console.WriteLine("\nVälj ett bokningsintervall från följande tillgängliga tider:");
            for (int i = 0; i < availableIntervals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableIntervals[i].Item1.ToShortDateString()} till {availableIntervals[i].Item2.ToShortDateString()}");
            }

            int intervalChoice = GetIntervalChoice(availableIntervals.Count);
            var chosenInterval = availableIntervals[intervalChoice - 1];

            if (RoomList.BookRoom(roomIndex, chosenInterval.Item1, chosenInterval.Item2))
            {
                Console.WriteLine($"Rum {RoomList.rooms[roomIndex - 1].RoomName} bokat från {chosenInterval.Item1.ToShortDateString()} till {chosenInterval.Item2.ToShortDateString()}.");
                
            }
            else
            {
                Console.WriteLine("Bokningen kunde inte genomföras.");
            }
        }

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
