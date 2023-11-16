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
                Console.WriteLine("\nÄr du en gäst eller en anställd? (G/A)\nTryck på 'Q' för att avsluta.");
                string input = Console.ReadLine()?.ToUpper() ?? "";

                switch (input)
                {
                    case "G":
                        HotelManagement.ChooseGuestProfile();
                        Menu.ShowGuestMenu();
                        break;
                    case "A":
                        MenuEmployee.ShowEmployeeMenu();
                        break;
                    case "Q":
                        Console.WriteLine("Avslutar programmet...");
                        return;
                    default:
                        Console.WriteLine("Felaktig inmatning. Välj antingen G, A eller Q.");
                        break;
                }
            }
        }
    }
}
