namespace hotelcsharp
{
    public class BookRoom
    {
        private RoomList roomList;

        // Konstruktor som tar emot en RoomList-instans
        public BookRoom(RoomList roomList)
        {
            this.roomList = roomList;
        }

        public void MakeBooking()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Tillgängliga rum:");
            Console.ResetColor();

            // Visar en lista över tillgängliga rum
            roomList.ListAvailableRooms();

            while (true)
            {
                Console.WriteLine("\nAnge numret på det rum du vill boka [1-3] eller 0 för att avbryta:");
                string userInput = Console.ReadLine();

                // Kontrollerar om användaren har matat in ett giltigt tal
                if (int.TryParse(userInput, out int roomIndex))
                {
                    // Om användaren anger 0, avbryts bokningsprocessen
                    if (roomIndex == 0)
                    {
                        break;
                    }
                    // Kontrollerar om det valda rumindexet är giltigt
                    if (roomIndex > 0 && roomIndex <= roomList.rooms.Count)
                    {
                        roomList.ShowInfoRoom(roomIndex);
                        Console.Write("\nVill du boka detta rum? (ja/nej): ");
                        userInput = Console.ReadLine();
                        
                        // Kontrollerar om användaren bekräftar bokningen
                        if (userInput.Equals("ja", StringComparison.OrdinalIgnoreCase))
                        {
                            // Bokar det valda rummet
                            roomList.BookRoom(roomIndex);
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                    }
                }
            }
        }
    }
}
