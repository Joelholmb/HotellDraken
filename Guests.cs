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
}    