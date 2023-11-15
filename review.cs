

class Review
{

    static void ReviewUI()
    {
        Console.WriteLine("1. Multiple choice");
        Console.WriteLine("2. Free text");
        Console.WriteLine("3. Number choice 1-10");

    }

    static void Review()
    {

        List<Review> Reviews = new List<Review>();


        Review a;
        a = new MultiChoice("", 100, "1", "2", "3", "4", "5");
        Review.Add(a);

        a = new FreeText("What can my company do to better serve your needs?", 200, "", "");
        Review.Add(a);
        a = new FreeText("How satisfied are you with our products/services?", 200, "", "");
        Review.Add(a);
        a = new FreeText("What value do we provide?", 200, "", "");
        Review.Add(a);
        a = new FreeText("What do you like our hotel?", 200, "", "");
        Review.Add(a);
        a = new FreeText("How is your stay?", 200, "", "");
        Review.Add(a);
    }
}







