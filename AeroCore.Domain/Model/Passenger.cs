using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroCore.Domain.Model
{
    public class Passengerfg
    {
        public int Id { get; set; }
        public string PassengerName { get; set; } = string.Empty;
        public int PassportNumber { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
