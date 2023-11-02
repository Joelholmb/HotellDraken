using System;

namespace hotelcsharp
{
    class Program
    {
        public static void Main()
        {
            GuestList guestList = new GuestList();
            RoomList roomList = new RoomList();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Ange numret på det rum du vill boka [1-3]\n");
            Console.ResetColor();

            roomList.ListAvailableRooms();
            string input = Console.ReadLine();
            
            bool Available = int.TryParse(input, out int roomIndex);

            if (Available && roomIndex > 0 && roomIndex <= roomList.room.Count)
            {
                roomList.BookRoom(roomIndex);
            }
            else
            {
                Console.WriteLine("Ogiltigt val. Försök igen.");
            }
                
        }
    }
}

