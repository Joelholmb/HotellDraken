namespace hotelcsharp
{


    public class RoomInfo
    {
        public Rooms Rooms { get; set; }
        public int RoomNumber { get; set; }
        public string TypeBed { get; set; }
        public string RoomSize { get; set; }
        public string RoomView {get; set; }
        public bool IsBooked { get; set; }
        
        

        public RoomInfo(int roomnumber,string typebed, string roomsize, string roomview)
        {
            RoomNumber = roomnumber;
            TypeBed = typebed;
            RoomSize = roomsize;
            RoomView = roomview;
        }
    }
}
        