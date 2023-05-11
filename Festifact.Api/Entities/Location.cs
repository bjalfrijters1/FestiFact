namespace Festifact.Api.Entities
{
    /* Capacity is apparently not a factor for PERFORMANCES...
     */
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Capacity { get; set; }
        public string? gps { get; set; }
    }
}
