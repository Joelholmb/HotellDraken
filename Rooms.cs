namespace hotelcsharp
{


    public class Rooms
    {
        public string RoomName { get; set; }
        public string RoomType { get; set; }
        public int RoomNumber { get; set; }
        public string TypeBed { get; set; }
        public string RoomPrice { get; set; }
        public string RoomSize { get; set; }
        public string RoomView {get; set; }
        public bool IsBooked { get; set; }
        

        public Rooms(string roomname, string roomtype, int roomnumber,string typebed, string roomsize, string roomview, string roomprice)
        {
            RoomName = roomname;
            RoomType = roomtype;
            RoomNumber = roomnumber;
            RoomPrice = roomprice;
            TypeBed = typebed;
            RoomSize = roomsize;
            RoomView = roomview;
            IsBooked = false;
            
        }
        
        

    }
}    