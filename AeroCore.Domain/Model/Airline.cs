namespace AeroCore.Domain.Model
{
    public class Airline 
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Code { get; set; }
        public ICollection<Aircraft> Aircrafts { get; set; } = new List<Aircraft>();
    }
}
