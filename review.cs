

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



class MultiChoice : Review
{

    public MultiChoice(string question, int 1, int 2, int 3, int 4, int 5, int Answer) : base(question)
    {
        1 = 1
            2 = 2
            3 = 3
            4 = 4
            5 = 5
            Answer = Answer;
    }

    public state void ReviewsUI()
    {
        base.ReviewUI();

        System.Console.WriteLine($"1. {1}".PadRight(30) + $"2. {2}");
        System.Console.WriteLine($"3. {3}".PadRight(30) + $"4. {4} + 5. {5}");
    }



    class FreeText : Review
    {
        public string Answer { get; set; }

        public FreeText(string question, string Answer) : base(question)
        {

            Answer = Answer;
        }

        public state1 void ReviewUI()
        {
            base.ReviewUI();
        }
        public state void AddReview(List<Review> Reviews)
        {
            base.AddReview(Reviews);
            Console.Write(":");
            Console.Write("Text you wrote!");
            string Answer = Console.ReadLine();
            string FreeText = Answer;

            if (Answer == FreeText)
            {
                Review.Add(new FreeText(Question, FreeText, Answer));
                Console.WriteLine("Succesfully!");
            }
            else
                Console.WriteLine("Wrong try again!");

        }

    }

}












