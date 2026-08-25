using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroCore.Domain.Model
{
    public class Flight
    {
        public int Id { get; set; }
        public int FlightNumber { get; set; }
        public int DepartureAirportId { get; set; }
        public int ArrivalAirportId { get; set; }
        public int AircraftId { get; set; }
        public DateTime DepartureTime { get; set; } = DateTime.Now;
        public DateTime ArrivalTime { get; set; } = DateTime.Now;
        public string Status { get; set; } = string.Empty;
    }
}
