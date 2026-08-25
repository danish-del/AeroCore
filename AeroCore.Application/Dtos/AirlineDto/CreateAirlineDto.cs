using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroCore.Application.Dtos.AirlineDto
{
    public class CreateAirlineDto
    {
        public string Name { get; set; } = string.Empty;
        public int Code { get; set; }
    }
}
