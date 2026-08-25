using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroCore.Application.Dtos.AircraftDto
{
    public class UpdateAircraftDto
    {
        public int Id { get; set; }
        public int RegistrationNumber { get; set; }
        public string Model { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public int AirlineId { get; set; }
    }
}
