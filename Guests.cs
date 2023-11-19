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
    }

        public class GuestList
    {
        public static List<Guest> guests = new List<Guest>
        {
        new Guest("Alfons", "Glassgatan 12", "0733111111", "inget@harjag.com"),
        new Guest("Laban", "Melonvägen 5", "07332222222", "ett@jaghar.com"),
        new Guest("Professor Baltazar", "Rödferrarigatan 45", "0733333333", "jaghartroligtvisett@trottsallt.com"),
        };
    }
}
    