using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroCore.Domain.Model
{
    public class BordingPass
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int GateId { get; set; }
        public int SeatNo { get; set; }
        public string Barcode { get; set; } = string.Empty; 
    }
}
