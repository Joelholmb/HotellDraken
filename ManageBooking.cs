namespace hotelcsharp
{ 
    class ManageBooking
    {   
        private RoomList roomList;

        public ManageBooking(RoomList roomList)
        {
            this.roomList = roomList;
        }


        public void CancelBooking()
        {
            //kontrollerar om bokningen har avbokats
            bool isCancelled = false;

            while (isCancelled == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ange bokningsnummer för det rum du vill avboka (eller 0 för att avsluta):");
                Console.ResetColor();

                roomList.ListBookedRooms();
                //Läser in användarens inmatning som en sträng även fast man skriver ett heltal eller sträng eller någon annan typ av data.
                string userInput = Console.ReadLine();
                // Försöker konvertera inmatningen till en integer(int)
                if (int.TryParse(userInput, out int bookingNumber))
                {
                    if (bookingNumber == 0)
                    {
                        break;
                    }
                    // Försöker avboka rummet och kontrollerar om det lyckades
                    if (roomList.CancelRoomBooking(bookingNumber))
                    {
                        Console.WriteLine($"Bokning av rum {bookingNumber} har avbokats.");
                        isCancelled = true;  // Uppdaterar den booleanska flaggan till true för att avsluta loopen
                    }
                    }
                    else
                    {
                        Console.WriteLine($"Ogiltigt bokningsnummer eller rummet är inte bokat. Försök igen.");
                    }
            }
        }
    }
}

