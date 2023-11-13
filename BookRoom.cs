namespace hotelcsharp
{
    public class BookRoom
    {
        RoomList roomList = RoomList.GetInstance();


        public void MakeBooking()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Tillgängliga rum:");
            Console.ResetColor();

            roomList.ListAvailableRooms();

            while (true)
            {
                Console.WriteLine("\nAnge numret på det rum du vill boka [1-3] eller 0 för att avbryta:");
                string userInput = Console.ReadLine();
                
                if (int.TryParse(userInput, out int roomIndex))
                {
                    if (roomIndex == 0)
                    {
                        break;
                    }

                    if (roomIndex > 0 && roomIndex <= roomList.rooms.Count)
                    {
                        roomList.ShowInfoRoom(roomIndex);
                        Console.Write("\nVill du boka detta rum? (ja/nej): ");
                        userInput = Console.ReadLine();
                        
                        if (userInput.Equals("ja", StringComparison.OrdinalIgnoreCase))
                        {
                            roomList.BookRoom(roomIndex);
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                    }
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning. Ange ett tal mellan 1 och 3, eller 0 för att avbryta.");
                }
            }
        }
    }
}
