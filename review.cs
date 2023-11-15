class Program
{
   
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.Clear();
            Console.WriteLine("1. Multiple choice");
            Console.WriteLine("2. Free text");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    foreach (Review review in Reviews)
                    {
                        review.ReviewUI();
                    }
                    break;

                case "2":
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
                    {
                        MultiChoice newReview = new MultiChoice("", 1, 2, 3, 4, 5, 0);
                        newReview.AddReview(Reviews);
                    }
                    else if (choice == 2)
                    {
                        FreeText newReview = new FreeText("", "");
                        newReview.AddReview(Reviews);
                    }
                    else
                    {
                        Console.WriteLine("Wrong input!");
                    }
                    break;
            }
        }
    }

    class Review
    {
        // Your Review class implementation...
    }

    class MultiChoice : Review
    {
        // Your MultiChoice class implementation...
    }

    class FreeText : Review
    {
        // Your FreeText class implementation...
    }
}
