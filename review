sing System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;


class Program
{

    static void ReviewUI()
    {
        Console.WriteLine("1. Multiple choice");
        Console.WriteLine("2. Free text");
        Console.WriteLine("3. Number choice 1-10");

    }

    static void Main()
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
RandomReviews.AddRange(Questions1);
RandomReviews.AddRange(Questions2);


bool Running = true;

while (Running)
{
    Console.Clear();
    MenuUI();

    string input = Console.ReadLine();

    switch (input)
    {
        case "1":
            foreach (Reviews A in Reviews)
            {
                A.ReviewsUI();
            }
            break;
        case "2":
            Console.Clear();
            AddReviewUI();
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {

                MultiChoice newReview = new MultiChoice("", , "", "", "", "", ); newReview.AddReview(Reviews);
            }

            else if (choice == 3)
            {

                FreeText newReview = new FreeText("", , "", ""); newReview.AddReview(Review);
            }
            break;

            foreach (Review A in RandomReviews)
            {
                
                Console.WriteLine($"Name: {name}");
                A.ReviewsUI();

                if (A is FreeText)
                {
                    
                    string stringanswer = Console.ReadLine();

                }
            }
    }   }

}


class MultiChoice : Review
{
    public int 1 { get; set; }
    public int 2 { get; set; }
    public int 3 { get; set; }
    public int 4 { get; set; }
    public int 5 { get; set; }

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

public state void AddReview(List<Review> Reviews)  
{
    base.AddReview(Reviews);

    int[] 12345 = new int[5];
    for (int i = 0; i < 5; i++)
    {
        Console.Write($" {(char)(65 + i)}: ");
        12345[i] = Console.ReadLine();
    }
    int answer = int.Parse(Console.ReadLine());
    if ((12345, x => int.Parse(x) == answer))
    {
        Review.Add(new MultiChoice(Question, 12345[0], 12345[1], 12345[2], 12345[3], 12345[4], answer));
        Console.WriteLine("Succesfully!");
    }
    else
    {
    Console.WriteLine("Wrong try again!");
    Thread.Sleep(2000);
    }
}


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












