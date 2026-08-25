using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroCore.Domain.Model
{
    public class Airport
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
