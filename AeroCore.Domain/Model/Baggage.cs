using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroCore.Domain.Model
{
    public class Baggage
    {
        public int Id { get; set; }
        public int PassengerId { get; set; }
        public int weight { get; set; }
        public int TagNumber { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
