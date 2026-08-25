using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroCore.Application.Dtos.BaggageDto
{
    public class CreateBaggageDto
    {
        public int PassengerId { get; set; }
        public int weight { get; set; }
        public int TagNumber { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
