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
        public List<(DateTime start, DateTime end)> BookedPeriods { get; private set; }
        // En lista som innehåller datumintervall när rummet är bokat
        

        public Rooms(string roomname, string roomtype,string typebed, string roomsize, string roomview, string roomprice)
        {
            RoomName = roomname;
            RoomType = roomtype;
            RoomPrice = roomprice;
            TypeBed = typebed;
            RoomSize = roomsize;
            RoomView = roomview;
            IsBooked = false;
            BookedPeriods = new List<(DateTime start, DateTime end)>();
            
        }
        // Metod för att boka rummet. Sätter IsBooked till true och tilldelar ett bokningsnummer
        public void Book(DateTime startDate, DateTime endDate)
        {
            foreach (var period in BookedPeriods)
            {
                if (startDate < period.end && endDate > period.start)
                {
                    Console.WriteLine("Detta datumintervall är redan bokat.");
                    return;
                }
            }

            BookedPeriods.Add((startDate, endDate));
            IsBooked = true;
            BookingNumber = nextBookingNumber++;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n--------------------------");
            Console.WriteLine($"Ditt bokningsnummer är: {BookingNumber}.");
            Console.WriteLine("--------------------------");
            Console.ResetColor();
            
        }
        // Metod för att avboka rummet. Återställer IsBooked till false
        public void CancelBooking()
        {
            // Kontrollera om det finns bokade intervaller
            if (IsBooked && BookedPeriods.Count > 0)
            {
                BookedPeriods.Clear(); // Rensa listan över bokade intervaller
                IsBooked = false; // Markera rummet som ej bokat
            }
        }
        //Metod för att kolla nör rum är lediga
        public void ShowAvailability()
        {
            
            Console.WriteLine($"Tillgänglighet för {RoomName}:");

            // Definierar startdatumet för tillgänglighetskontrollen, vilket är dagens datum
            DateTime checkDate = DateTime.Now;
            // Definierar slutdatumet för tillgänglighetskontrollen, vilket är en månad från dagens datum
            DateTime endDate = DateTime.Now.AddMonths(1); 

            // En while-loop som kör tills checkDate når endDate
            while (checkDate < endDate)
            {
                // rummet är tillgängligt från början
                bool isAvailable = true;
                
                // Går igenom varje bokningsperiod för rummet
                foreach (var period in BookedPeriods)
                {
                    // Kontrollerar om checkDate faller inom någon bokad period
                    if (checkDate >= period.start && checkDate < period.end)
                    {
                        // Om det gör det, är rummet inte tillgängligt den dagen
                        isAvailable = false;
                        break;
                    }
                }

                // Om rummet är tillgängligt, då skrivs det datumet ut som tillgängligt
                if (isAvailable)
                {
                    Console.WriteLine($"{checkDate.ToShortDateString()} - Tillgänglig");
                }
                // Går vidare till nästa dag
                checkDate = checkDate.AddDays(1);
            }
        }
    }
}
  