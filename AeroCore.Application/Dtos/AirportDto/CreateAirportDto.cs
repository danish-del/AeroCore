using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroCore.Application.Dtos.AirportDto
{
    public class CreateAirportDto
    {
        public string? Name { get; set; } = string.Empty;
        public int Code { get; set; }
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
