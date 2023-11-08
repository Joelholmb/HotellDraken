using System;

namespace hotelcsharp
{
    class Program
    {
        public static void Main()
        {
            HotelManagement hotelManagement = new HotelManagement();
            hotelManagement.ChooseRole();

            BookRoom bookRoom = new BookRoom();
            bookRoom.MakeBooking();


        }

    }
}
