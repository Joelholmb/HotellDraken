using System;
using System.Collections.Generic;

class Program
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

    static void Main()
    {
        List<HotelReview> reviews = new List<HotelReview>();

        bool keepRunning = true;

        while (keepRunning)
        {
            Console.Clear();
            Console.WriteLine("Hotel Review System");
            Console.WriteLine("1. Write a Review");
            Console.WriteLine("2. View Reviews");
            Console.WriteLine("3. Exit");

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
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void LeaveReview(List<HotelReview> reviews)
    {
        Console.Clear();
        Console.WriteLine("Write a Review");

        Console.Write("Your Name: ");
        string userName = Console.ReadLine();

        Console.Write("Rating (1-5): ");
        int rating;
        while (!int.TryParse(Console.ReadLine(), out rating) || rating < 1 || rating > 5)
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            Console.Write("Rating (1-5): ");
        }

        Console.Write("Comment: ");
        string comment = Console.ReadLine();

        HotelReview review = new HotelReview(userName, rating, comment);
        reviews.Add(review);

        Console.WriteLine("Thank you for your review!");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    static void ViewReviews(List<HotelReview> reviews)
    {
        Console.Clear();
        Console.WriteLine("Hotel Reviews");

        if (reviews.Count == 0)
        {
            Console.WriteLine("No reviews available.");
        }
        else
        {
            foreach (HotelReview review in reviews)
            {
                Console.WriteLine(review);
            }
        }

        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}
