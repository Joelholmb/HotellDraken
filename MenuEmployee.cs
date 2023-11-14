namespace hotelcsharp
{
    class MenuEmployee
    {
        private RoomList roomList = RoomList.GetInstance();

        public void ShowEmployeeMenu()
        {
            bool isRunning = true;
            while(isRunning)
            {
                Console.WriteLine("=========================");
                Console.WriteLine("[1] Tillgängliga rum.");
                Console.WriteLine("[2] Checka in gäst.");
                Console.WriteLine("[3] Underhåll rum.");
                Console.WriteLine("[4] Checka ut gäst");
                Console.WriteLine("[5] Avsluta.");
                Console.WriteLine("Ange ditt val: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                    ShowAvailableRooms(); 
                        break;
                    case "2":
                    CheckInGuest();
                        break;
                    case "3":

                        break;
                    case "4":
                    CheckOutGuest();
                        break;
                    case "5":
                        Console.WriteLine("Avslutar programmet...");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
            }
        }

        public void ShowAvailableRooms()
        {
            Console.WriteLine("Tillgängliga rum:");
            bool availableRoomFound = false;

            foreach (var room in roomList.rooms)
            {
                if (room.IsBooked == false)
                {
                    Console.WriteLine($"Rum: {room.RoomName}");
                    availableRoomFound = true;
                }
            }

            if (availableRoomFound == false)
            {
                Console.WriteLine("Inga lediga rum just nu.");
            }

        }
        public void CheckInGuest()
        {
            Console.Write("Ange bokningsnummer för incheckning: ");
            int bookingNumber = int.Parse(Console.ReadLine());

            var roomList = RoomList.GetInstance();
            bool roomFound = false;

            
            foreach (var room in roomList.rooms)
            {
                if (room.BookingNumber == bookingNumber && room.IsBooked)
                {
                    roomFound = true;
                    
                    Console.WriteLine($"Gäst har checkats in i rum {room.RoomName} med bokningsnummer {bookingNumber}.");
                    break;
                }
            }

            if (roomFound == false)
            {
                Console.WriteLine("Ingen giltig bokning hittades för detta bokningsnummer.");
            }
        }

        public void CheckOutGuest()
        {
            Console.Write("Ange bokningsnummer för utcheckning: ");
            int bookingNumber;
            while (!int.TryParse(Console.ReadLine(), out bookingNumber))
            {
                Console.Write("Felaktigt format, ange bokningsnummer igen: ");
            }

            var roomList = RoomList.GetInstance();
            bool roomFound = false;

            foreach (var room in roomList.rooms)
            {
                if (room.BookingNumber == bookingNumber && room.IsBooked)
                {
                    roomFound = true;
                    room.IsBooked = false;
                    
                    Console.WriteLine($"Gäst har checkats ut från rum {room.RoomName} med bokningsnummer {bookingNumber}.");
                    break;
                }
            }

            if (roomFound == false)
            {
                Console.WriteLine("Ingen giltig bokning hittades för detta bokningsnummer.");
            }
        }
    }
}
