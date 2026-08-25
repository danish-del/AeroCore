namespace AeroCore.Domain.Model
{
    public class Aircraft
    {
        public int Id { get; set; }
        public int RegistrationNumber { get; set; }
        public string Model { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public int AirlineId { get; set; }
        public Airline? Airline { get; set; } 


    }
}
