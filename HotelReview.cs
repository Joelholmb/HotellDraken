namespace hotelcsharp
{
    class Review
    {
        // Define a class for reviews
        public class HotelReview
        {
            public string UserName { get; set; }
            public int Rating { get; set; }
            public string Comment { get; set; }

            public HotelReview(string userName, int rating, string comment)
            {
                UserName = userName;
                Rating = rating;
                Comment = comment;
            }

            public override string ToString()
            {
                return $"User: {UserName}\nRating: {Rating}\nComment: {Comment}\n";
            }
        }

        public static void ReviewMenu()
         {
            List<HotelReview> reviews = new List<HotelReview>();

             bool keepRunning = true;

             while (keepRunning)
             {
                 Console.Clear();
                 Console.WriteLine("Vad kul! Gör nu ditt val.");
                 Console.WriteLine("1. Skriv en recension.");
                 Console.WriteLine("2. Kolla vad du lämnat för recension tidigare.");
                 Console.WriteLine("3. Avsluta.");

                 string choice = Console.ReadLine();

                 switch (choice)
                 {
                     case "1":
                         LeaveReview(reviews);
                         break;
                     case "2":
                         ViewReviews(reviews);
                         break;
                     case "3":
                         keepRunning = false;
                         break;
                     default:
                         Console.WriteLine("Fel val! Försök igen.");
                        break;
                 }
             }
        }

        static void LeaveReview(List<HotelReview> reviews)
        {
            Console.Clear();
            Console.WriteLine("Skriv en recension");

            Console.Write("Namn: ");
            string userName = Console.ReadLine();

            Console.Write("Rating (1-5): ");
            int rating;
            while (!int.TryParse(Console.ReadLine(), out rating) || rating < 1 || rating > 5)
            {
                Console.WriteLine("Fel inmatning! Skriv in en siffra mellan 1-5.");
                Console.Write("Rating (1-5): ");
            }

            Console.Write("Kommentar: ");
            string comment = Console.ReadLine();

            HotelReview review = new HotelReview(userName, rating, comment);
            reviews.Add(review);

            Console.WriteLine("Tack för din recension, den betyder mycket för oss!");
            Console.WriteLine("Valfri tangent för att fortsätta...");
            Console.ReadLine();
        }

        static void ViewReviews(List<HotelReview> reviews)
        {
            Console.Clear();
            Console.WriteLine("Hotellrecensioner");

            if (reviews.Count == 0)
            {
                Console.WriteLine("Inga recensioner tillgängliga.");
            }
            else
            {
                foreach (HotelReview review in reviews)
                {
                    Console.WriteLine(review);
                }
            }

            Console.WriteLine("Valfri tangent för att fortsätta...");
            Console.ReadLine();
        }
    }
}
