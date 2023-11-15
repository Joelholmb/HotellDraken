public class Review1
{
Public void R1()
    {
        Console.WriteLine("1. Multiple choice");
        Console.WriteLine("2. Free text");
        Console.WriteLine("3. Number choice 1-10");
    }


    class MultiChoice : Review1
    {
        public int Option1 { get; set; }
        public int Option2 { get; set; }
        public int Option3 { get; set; }
        public int Option4 { get; set; }
        public int Option5 { get; set; }
        public int Answer { get; set; }

        public MultiChoice(string question, int option1, int option2, int option3, int option4, int option5, int answer)
        {
            Option1 = option1;
            Option2 = option2;
            Option3 = option3;
            Option4 = option4;
            Option5 = option5;
            Answer = answer;
        }

        public void Review1UI()
        {

            Console.WriteLine($"Options: {Option1}, {Option2}, {Option3}, {Option4}, {Option5}");
            Console.WriteLine($"Answer: {Answer}");
            Console.WriteLine();
        }
    }

    static void Review1UI()
    {
        // Declare the list outside the method
        List<Review1> Reviews = new List<Review1>();

        // Instantiate the objects and add them to the list
        Review1 a = new MultiChoice("MultiChoice Question", 1, 2, 3, 4, 5, 3);
        Reviews.Add(a);
        a = new MultiChoice("MultiChoice Question", 1, 2, 3, 4, 5, 3);
        Reviews.Add(a);
        a = new MultiChoice("MultiChoice Question", 1, 2, 3, 4, 5, 3);
        Reviews.Add(a);

        FreeText freeText1 = new FreeText("What can my company do to better serve your needs?", "Answer 1");
        Reviews.Add(freeText1);

        FreeText freeText2 = new FreeText("How satisfied are you with our products/services?", "Answer 2");
        Reviews.Add(freeText2);

        FreeText freeText3 = new FreeText("What value do we provide?", "Answer 3");
        Reviews.Add(freeText3);

        FreeText freeText4 = new FreeText("What do you like our hotel?", "Answer 4");
        Reviews.Add(freeText4);

        FreeText freeText5 = new FreeText("How is your stay?", "Answer 5");
        Reviews.Add(freeText5);
    }

    class FreeText : Review1
    {
        public string Answer { get; set; }

        public FreeText(string question, string answer)
        {
            Answer = answer;
        }
    }
}





}
