namespace AeroCore.Domain.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public int BookingNumber { get; set; }
        public int PassengerId { get; set; }
        public int FlightId { get; set; }
        public int SeatNo { get; set; }
        public int Price { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
