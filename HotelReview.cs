public class GuestReview
{
    Public void R1()
    {
        Console.WriteLine("1. Multiple choice");
        Console.WriteLine("2. Free text");
        Console.WriteLine("3. Number choice 1-10");
    }


    class MultiChoice : GuestReview
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

        public void ReviewUI()
        {

            Console.WriteLine($"Options: {Option1}, {Option2}, {Option3}, {Option4}, {Option5}");
            Console.WriteLine($"Answer: {Answer}");
            Console.WriteLine();
        }
    }

    static void Review()
    {
        List<GuestReview> Reviews = new List<GuestReview>();

        // Creating a new instance of MultiChoice
        GuestReview a = new MultiChoice("MultiChoice Question", 1, 2, 3, 4, 5, 3);
        Reviews.Add(a);


    }

}
