namespace hotelcsharp
{


    public class Rooms
    {
        public string RoomName { get; set; }
        public string RoomType { get; set; }
        public int RoomNumber { get; set; }

        public string RoomPrice { get; set; }
        

        public Rooms(string roomname, string roomtype, int roomnumber, string roomprice)
        {
            RoomName = roomname;
            RoomType = roomtype;
            RoomNumber = roomnumber;
            RoomPrice = roomprice;
            
        }
        
        

    }
}    