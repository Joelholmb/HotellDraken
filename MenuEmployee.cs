namespace hotelcsharp
{
    class MenuEmployee
    {
        private RoomList roomList = RoomList.GetInstance();

        public void ShowEmployeeMenu()
        {
            bool isRunning = true;
            while(isRunning)
            {
                Console.WriteLine("=========================");
                Console.WriteLine("[1] Underhåll rum.");
                Console.WriteLine("[2] Checka in gäst.");
                Console.WriteLine("[3] Tillgängliga rum.");
                Console.WriteLine("[4] Checka ut gäst");
                Console.WriteLine("[5] Avsluta.");
                Console.WriteLine("Ange ditt val: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        
                        break;
                    case "2":
                        
                        break;
                    case "3":

                        break;
                    case "4":
                    
                        break;
                    case "5":
                        Console.WriteLine("Avslutar programmet...");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
            }
        }
    }
}
