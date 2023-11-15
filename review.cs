

class Review
{


    static void MenuUI()
    {
        Console.WriteLine("1. Multiple choice");
        Console.WriteLine("2. Free text");


    }

    static void Review()
    {

        List<Review> Reviews = new List<Review>();


        Review a;
        a = new MultiChoice("", 100, "1", "2", "3", "4", "5");
        Review.Add(a);

        a = new FreeText("What can my company do to better serve your needs?", "");
        Review.Add(a);
        a = new FreeText("How satisfied are you with our products/services?", "");
        Review.Add(a);
        a = new FreeText("What value do we provide?", "");
        Review.Add(a);
        a = new FreeText("What do you like our hotel?", "");
        Review.Add(a);
        a = new FreeText("How is your stay?", "");
        Review.Add(a);
    }
    class MultiChoice : Review
    {
        public int Option1 { get; set; }
        public int Option2 { get; set; }
        public int Option3 { get; set; }
        public int Option4 { get; set; }
        public int Option5 { get; set; }
        public int Answer { get; set; }

        public MultiChoice(string question, int option1, int option2, int option3, int option4, int option5, int answer) : base(question)
        {
            Option1 = option1;
            Option2 = option2;
            Option3 = option3;
            Option4 = option4;
            Option5 = option5;
            Answer = answer;
        }

        public override void ReviewUI()
        {
            Console.WriteLine($"Question: {Question}");
            Console.WriteLine($"Options: {Option1}, {Option2}, {Option3}, {Option4}, {Option5}");
            Console.WriteLine($"Answer: {Answer}");
            Console.WriteLine();
        }
    }


    public override void ReviewUI()
    {
    // Add logic to display MultiChoice review UI
    Console.WriteLine($"Question: {Question}");
    Console.WriteLine($"Options: {1}, {2}, {3}, {4}, {5}");
    Console.WriteLine($"Answer: {Answer}");
    Console.WriteLine();
    }


    bool keepRunning = true;

    while (keepRunning)
    {
        Console.Clear();

        string input = Console.ReadLine();

        switch (input)
        {
        case "1":
            foreach (Review a in Reviews)
            {
                A.ReviewUI();
            }
            break;
        case "2":
            int choice = int.Parse(Console.ReadLine());
            if (choice = 1)
            {

                MultiChoice newReview = new MultiChoice("", 0, "", "", "", "", 0); newReview.AddReview(Reviews);
            }
            else if (choice = 2)
            {

                FreeText newReview = new FreeText("", 0, "", ""); newReview.AddReview(Reviews);
            }
            else
            {
                System.Console.WriteLine("Wrong input!");

            }
            break;
        }
    }
}















