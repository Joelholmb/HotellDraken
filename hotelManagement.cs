namespace nytthotell
{

    public class HotelManagement
    {
        public string userRole;

        public void ChooseRole()
        {
            Console.WriteLine("Är du en gäst eller en anställd? (G/A)");
            string input = Console.ReadLine();

            if (input.Equals("G", StringComparison.OrdinalIgnoreCase))
            {
                userRole = "Gäst";
                ManageGuest();
            }
            else if (input.Equals("A", StringComparison.OrdinalIgnoreCase))
            {
                userRole = "Anställd";
                ManageEmployee();
            }
            else
            {
                Console.WriteLine("Felaktig inmatning. Välj antingen G eller A.");
                ChooseRole();
            }
        }

        private void ManageGuest()
        {
            
            Console.WriteLine("Välkommen, gäst! Låt oss hjälpa dig med din vistelse.");
            
        }

        private void ManageEmployee()
        {
            
            Console.WriteLine("Välkommen tillbaka, kollega!");
            
        }
    }
}