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

            while (true)
            {
                Console.WriteLine("\nAnge numret på det rum du vill boka [1-3] eller 0 för att avbryta:");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int roomIndex) && roomIndex > 0 && roomIndex <= RoomList.rooms.Count)
                {
                    RoomList.ShowInfoRoom(roomIndex);
                    Console.Write("\nVill du boka detta rum? (ja/nej): ");
                    userInput = Console.ReadLine();
                    
                    if (userInput.Equals("ja", StringComparison.OrdinalIgnoreCase))
                    {
                        var availableIntervals = RoomList.GetAvailableWeekIntervals(roomIndex, 4);
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
                        bool bookingSuccess = RoomList.BookRoom(roomIndex, chosenInterval.Item1, chosenInterval.Item2);
                        if (bookingSuccess)
                        {
                            Console.WriteLine($"Rum {RoomList.rooms[roomIndex - 1].RoomName} bokat från {chosenInterval.Item1.ToShortDateString()} till {chosenInterval.Item2.ToShortDateString()}.");
                        }
                        else
                        {
                            Console.WriteLine("Bokningen kunde inte genomföras.");
                        }
                        break;
                    }
                }
                else if (roomIndex == 0)
                {
                    Console.WriteLine("Bokning avbruten.");
                    break;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                }
            }
        }
    }
}

