namespace hotelcsharp
{ 
    public static class ManageBooking
    {   
        public static void CancelBooking()
        {
            bool isCancelled = false;
            while (!isCancelled)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ange bokningsnummer för det rum du vill avboka (eller 0 för att avsluta):");
                Console.ResetColor();

                // Lista alla bokade rum
                RoomList.ListBookedRooms();

                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int bookingNumber) && bookingNumber == 0)
                {
                    break;
                }
                else if (int.TryParse(userInput, out bookingNumber) && RoomList.CancelRoomBooking(bookingNumber))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Bokning av rum {bookingNumber} har avbokats.");
                    Console.ResetColor();
                    isCancelled = true;
                }
                else
                {
                    Console.WriteLine("Ogiltigt bokningsnummer eller rummet är inte bokat. Försök igen.");
                }
            }
        }
    }
}