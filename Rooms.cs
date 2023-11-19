namespace hotelcsharp
{
    public class Rooms
    {
        private static int nextBookingNumber = 1;
        // En statisk variabel som håller koll på nästa tillgängliga bokningsnummer
        public int RoomId { get; private set; }
        public string RoomName { get; set; }
        public string RoomType { get; set; }
        public int BookingNumber { get; private set; }
        public string TypeBed { get; set; }
        public string RoomPrice { get; set; }
        public string RoomSize { get; set; }
        public string RoomView { get; set; }
        public bool IsBooked { get; set; }

        public Rooms(int roomId, string roomName, string roomType, string typeBed,string roomSize, string roomView, string roomPrice)
        {
            RoomId = roomId;
            RoomName = roomName;
            RoomType = roomType;
            TypeBed = typeBed;
            RoomSize = roomSize;
            RoomView = roomView;
            RoomPrice = roomPrice;
            IsBooked = false;
        }

        public void Book()
        {
            if (IsBooked)
            {
                Console.WriteLine("Rummet är redan bokat.");
                return;
            }

            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddDays(7);

            IsBooked = true;
            BookingNumber = nextBookingNumber++;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n-------------------------------------------------");
            Console.WriteLine($"Bokningsbekräftelse för Hotell Draken. \nRum {RoomName} har bokats.");
            Console.WriteLine($"Ditt bokningsnummer är: {BookingNumber}.");
            Console.WriteLine($"Bokningsdatum: {startDate.ToShortDateString()} till {endDate.ToShortDateString()}");
            Console.WriteLine("-------------------------------------------------");
            Console.ResetColor();
        }

        public void CancelBooking()
        {
            if (IsBooked)
            {
                IsBooked = false;
                Console.WriteLine("Bokningen har avbokats.");
            }
        }

        public void ShowAvailability()
        {
            Console.WriteLine($"Tillgänglighet för {RoomName}: {(IsBooked ? "Bokat" : "Ledigt")}");
        }
    }
}
