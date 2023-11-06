using System;

namespace hotelcsharp
{
    class Program
    {
        public static void Main()
        {
            GuestList guestList = new GuestList();
            RoomList roomList = new RoomList();

            while(true)
            {

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Ange numret på det rum du vill boka [1-3], avsluta bokningen med '0'.\n");
                Console.ResetColor();

                roomList.ListAvailableRooms();
                string userinput = Console.ReadLine();
                
                bool Available = int.TryParse(userinput, out int roomIndex);

                if (Available && roomIndex > 0 && roomIndex <= roomList.room.Count)
                {
                    roomList.ShowInfoRoom(roomIndex);
                    Console.Write("\nVill du boka detta rum? (ja/nej): ");
                    string userInput = Console.ReadLine();
                    
                    if (userInput == "ja")
                    {
                        roomList.BookRoom(roomIndex);
                        break;
                    }
                }
                else if (Available && roomIndex == 0)
                {
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

