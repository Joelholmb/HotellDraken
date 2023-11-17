using System;

namespace hotelcsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Huvudmenyn som loopar tills man är nöjd med sin bokning som gäst eller hantering av bokning som anställd
            while (true)
            {
                Console.WriteLine("\nÄr du en gäst eller en anställd? (G/A)\nTryck på 'Q' för att avsluta");
                string input = Console.ReadLine().ToUpper();

                switch (input)
                {
                    case "G":
                        Console.Clear();
                        HotelManagement.ChooseGuestProfile();
                        Menu.ShowGuestMenu();
                        break;
                    case "A":
                        Console.Clear();
                        HotelManagement.LoginEmployee();
                        break;
                    case "Q":
                        Console.WriteLine("Klicka valfri tangent för att avsluta");
                        return;
                    default:
                        Console.WriteLine("Felaktig inmatning. Välj antingen G, A eller Q.");
                        break;
                }
            }
        }
    }
}
