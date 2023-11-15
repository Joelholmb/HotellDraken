namespace hotelcsharp
{


    public class Rooms
    {
        private static int nextBookingNumber = 1;
        // En statisk variabel som håller koll på nästa tillgängliga bokningsnummer

        public string RoomName { get; set; }
        public string RoomType { get; set; }
        public int BookingNumber { get; set; }
        public string TypeBed { get; set; }
        public string RoomPrice { get; set; }
        public string RoomSize { get; set; }
        public string RoomView {get; set; }
        public bool IsBooked { get; set; }
        

        public Rooms(string roomname, string roomtype,string typebed, string roomsize, string roomview, string roomprice)
        {
            RoomName = roomname;
            RoomType = roomtype;
            RoomPrice = roomprice;
            TypeBed = typebed;
            RoomSize = roomsize;
            RoomView = roomview;
            IsBooked = false;
            
        }
        // Metod för att boka rummet. Sätter IsBooked till true och tilldelar ett bokningsnummer
            public void Book()
        {
            if (IsBooked == false)
            {
                IsBooked = true;
                BookingNumber = nextBookingNumber++; // Ökar nästa bokningsnummer
                Console.WriteLine($"Rum {RoomName} bokat med bokningsnummer {BookingNumber}.");
            }
            else
            {
                Console.WriteLine("Rummet är redan bokat.");
            }
        }
        // Metod för att avboka rummet. Återställer IsBooked till false
        public void CancelBooking()
        {
            if (IsBooked)
            {
                IsBooked = false;
                
            }
        }
    }
}  