namespace hotelcsharp
{
    static class MenuEmployee
    {
        public static void ShowEmployeeMenu()
        {
            bool isRunning = true;
            while(isRunning)
            {
                Console.Clear();
                Console.WriteLine("=========================");
                Console.WriteLine("[1] Tillgängliga rum.");
                Console.WriteLine("[2] Checka in gäst.");
                Console.WriteLine("[3] Checka ut gäst");
                Console.WriteLine("[4] Logga ut.");
                Console.WriteLine("Ange ditt val: ");

                string choice = Console.ReadLine()+"";

                switch (choice)
                {
                    case "1":
                        ShowAvailableRooms(); 
                        break;
                    case "2":
                        Console.Clear();
                        ShowBookedRooms();
                        CheckInGuest();
                        break;
                    case "3":
                        Console.Clear();
                        ShowBookedRooms();
                        CheckOutGuest();
                        break;
                    case "4":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("===========================");
                        Console.WriteLine("Du har blivit utloggad.");
                        Console.WriteLine("===========================");
                        Console.ResetColor();
                        isRunning = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }
            }
        }
        public static void ShowBookedRooms()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Lista över bokade rum:");
            Console.ResetColor();
            foreach (var room in RoomList.rooms)
            {
                if (room.IsBooked)
                {
                    Console.WriteLine($"Bokningsnr: {room.BookingNumber}, Rum: {room.RoomName}");
                }
            }
        }

        public static void ShowAvailableRooms()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Tillgängliga rum:");
            Console.ResetColor();
            
            RoomList.ListAvailableRooms();
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn...");
            Console.ReadKey();
            Console.Clear();     
        
            
            bool availableRoomFound = false;
            // loopar genom rummen för att hitta lediga rum
            foreach (var room in RoomList.rooms)
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
        // Metod för att checka in en gäst
        public static void CheckInGuest()
        {
            Console.Write("Ange bokningsnummer för incheckning: ");
            int bookingNumber = int.Parse(Console.ReadLine()+"");

            bool roomFound = false;
            foreach (var room in RoomList.rooms)
            {
                if (room.BookingNumber == bookingNumber && room.IsBooked)
                {
                    roomFound = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Gäst har checkats in i rum {room.RoomName} med bokningsnummer {bookingNumber}.");
                    Console.ResetColor();
                    break;
                }
            }

            if (roomFound == false)
            {
                Console.WriteLine("Ingen giltig bokning hittades för detta bokningsnummer.");
            }
        }

        // Metod för att checka ut en gäst
        public static void CheckOutGuest()
        {
            Console.Write("Ange bokningsnummer för utcheckning: ");
            int bookingNumber;
            while (!int.TryParse(Console.ReadLine(), out bookingNumber))
            {
                Console.Write("Felaktigt format, ange bokningsnummer igen: ");
            }

            bool roomFound = false;
            foreach (var room in RoomList.rooms)
            {
                if (room.BookingNumber == bookingNumber && room.IsBooked)
                {
                    roomFound = true;
                    room.IsBooked = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Gäst har checkats ut från rum {room.RoomName} med bokningsnummer {bookingNumber}.");
                    Console.ResetColor();
                    PromptGuestForReview();
                    break;
                }
            }

            if (roomFound == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ingen giltig bokning hittades för detta bokningsnummer.");
                Console.ResetColor();
            }
        }
        public static void PromptGuestForReview()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n========================================================");
            Console.WriteLine("Kära gäst! Vill du recensera din vistelse? (ja/nej): ");
            Console.WriteLine("========================================================");
            Console.ResetColor();
            string response = Console.ReadLine()+"";

            if (response.Equals("ja", StringComparison.OrdinalIgnoreCase))
            {
                Review.ReviewMenu();
            }
        }
    }
}
