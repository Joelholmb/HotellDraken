namespace hotelcsharp
{ 
    class ManageBooking
    {   
        RoomList roomList = RoomList.GetInstance();


        public void CancelBooking()
        {
            bool isCancelled = false;

            while (!isCancelled)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ange bokningsnummer för det rum du vill avboka (eller 0 för att avsluta):");
                Console.ResetColor();

                roomList.ListBookedRooms();

                string userInput = Console.ReadLine();
                
                if (int.TryParse(userInput, out int bookingNumber))
                {
                    if (bookingNumber == 0)
                    {
                        break;
                    }

                    if (roomList.CancelRoomBooking(bookingNumber))
                    {
                        Console.WriteLine($"Bokning av rum {bookingNumber} har avbokats.");
                        isCancelled = true;
                    }
                    else
                    {
                        Console.WriteLine($"Ogiltigt bokningsnummer eller rummet är inte bokat. Försök igen.");
                    }
                }
            }
        }
    }
}
