

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

public MultiChoice(string question, int 1, int 2, int 3, int 4, int 5, int Answer) : base(question)
    {
    {
        1 = 1
        2 = 2
        3 = 3
        4 = 4
        5 = 5
        Answer = Answer;
    }
}

public FreeText(string question, string Answer) : base(question)
    {

    Answer = Answer;
}

    }

}












