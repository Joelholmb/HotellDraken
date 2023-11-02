using System;

namespace hotelcsharp
{
    class Program
    {
        public static void Main()
        {
           GuestList guestList = new GuestList();
           guestList.PrintGuestList(); 

           RoomList roomList = new RoomList();
           roomList.PrintRoomList();
        }
    }
}
//Test till Commit
