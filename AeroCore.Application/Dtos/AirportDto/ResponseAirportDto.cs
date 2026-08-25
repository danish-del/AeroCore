using AeroCore.Domain.Model;

namespace AeroCore.Application.Dtos.AirportDto
{
    public class ResponseAirportDto
    {
         public int Id { get; set; }
        public string? Name { get; set; } =string.Empty;
        public int Code { get; set; }
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public ICollection<Airline> Airlines { get; set; } = new List<Airline>();
        public ICollection<Aircraft> Aircraft { get; set; } = new List<Aircraft>();
    }
}
