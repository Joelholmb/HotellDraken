using System;

namespace hotelcsharp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            RoomList roomList = new RoomList();
            
            BookRoom bookRoom = new BookRoom(roomList);
            MenuEmployee menuEmployee = new MenuEmployee(roomList);

            HotelManagement hotelManagement = new HotelManagement(roomList);
            hotelManagement.ChooseRole();

        }

    }
}
