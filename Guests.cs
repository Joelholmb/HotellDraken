namespace hotelcsharp
{


    public class Guest
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        

        public Guest(string name, string address, string phoneNumber, string email)
        {
            Name = name;
            Adress = address;
            PhoneNumber = phoneNumber;
            Email = email;
            
        }
        // Överskriver metoden ToString för att returnera gästens namn när Guest-instansen anropas från ManageGuest som ligger under HotelManagement.cs.
        public override string ToString()
        {
            return Name;
        }



    }
}    