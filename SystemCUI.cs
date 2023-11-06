static class Program
{
    static void Main()
    {
        bool isRunning = true;
        while(isRunning)
        {
            Console.WriteLine("=========================")
            Console.WriteLine("[B]oka ett rum.");
            Console.WriteLine("Checka [i]n på ett hotellrum.");
            Console.WriteLine("Checka [u]t från a hotellrum.");
            Console.WriteLine("[A]vboka en bokning.");
            Console.WriteLine("A[v]sluta.");
            Console.WriteLine("Val: ");

            string choice = Console.ReadLine();

            switch (choice.ToLower())
            {
                case "b":
                SystemCUI.Book();
                break;

                case "i":
                SystemCUI.CheckIn();
                break;

                case"u":
                SystemCUI.CheckOut();
                break;

                case"a":
                SystemCUI.CancelBooking();
                break;

                case"v":
                Console.WriteLine("Avsluta...");
                isRunning = false;
                break;

                default:
                Console.WriteLine("Jag förstår inte...");
                break;
            }
        }
    }
}