public class CostumersReview
{
<<<<<<< HEAD
    internal class quiz
    {
        
=======
        {
            System.Console.WriteLine("[1] Svar på frågorna om hotellet");
            System.Console.WriteLine("[2] Skriv frågor");
            System.Console.WriteLine("[3] Orkar inte skriva frågor. Jag lämnar över till AI");
>>>>>>> 644c1b41fe5cd7380b6b2e81772a025248f2cea3

            string val = Console.ReadLine();

            switch (val)
            {
                case "1":

                    System.Console.WriteLine("");
                    string topic = Console.ReadLine();

                    System.Console.WriteLine("");
                    int number = int.Parse(Console.ReadLine());

                    break;

                case "2":

                    System.Console.WriteLine("Vad är frågan, SKRIV IN");
                    string text = Console.ReadLine();

                    System.Console.WriteLine("Vad är svaret, SKRIV IN");
                    string svar = Console.ReadLine();

                    System.Console.WriteLine("Vad är frågan, SKRIV IN");
                    string text2 = Console.ReadLine();

                    System.Console.WriteLine("Vad är svaret, SKRIV IN");
                    string svar2 = Console.ReadLine();

                    break;
            }
        }
}

