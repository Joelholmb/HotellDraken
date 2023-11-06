
namespace hotelcsharp
{
    public class RoomList
    {
        public List<Rooms> room = new List<Rooms>
        {
        new Rooms("Lancelot", "Superior-rum", 13,"2 enkelsängar", "26 kvadratmeter","en betongvägg", "3700 kr"),
        new Rooms("Merlin", "Premium-rum",22, "1 queen-size säng", "36 kvadratmeter","staden", "5000 kr"),
        new Rooms("Arthur", "Svit", 1, "1 kingsize-säng", "49 kvadratmeter","havet", "12000 kr"),
        };
        
            
        
        public void ListAvailableRooms()
        {
           int index = 1;
           foreach (var currentroom in room)
           {
              if (currentroom.IsBooked == false)
              {
                 Console.WriteLine($"{index}. {currentroom.RoomName}, {currentroom.RoomType}.\n   Pris för en natt {currentroom.RoomPrice}.\n");
              }
              index++;
           }
        }

        public void BookRoom(int roomIndex)
        {
            
            if (roomIndex > 0 && roomIndex <= room.Count && room[roomIndex - 1].IsBooked == false)
            {
                room[roomIndex - 1].IsBooked = true;
                Console.WriteLine($"Rummet {room[roomIndex - 1].RoomName} har bokats.");
            }
            else
            {
                Console.WriteLine("Ogiltigt val eller rummet är inte tillgängligt för bokning.");
            }
        }

        public void ShowInfoRoom(int roomIndex)
        {
            var selectedRoom = room[roomIndex - 1];
            Console.WriteLine($"\nDu har valt rummet {selectedRoom.RoomName}");
            Console.WriteLine($"\n{selectedRoom.RoomType}");
            Console.WriteLine($"{selectedRoom.RoomSize}");
            Console.WriteLine($"{selectedRoom.TypeBed}");
            Console.WriteLine($"Utsikt över {selectedRoom.RoomView}");
            Console.WriteLine($"Pris per natt: {selectedRoom.RoomPrice}");
        }
   }


}