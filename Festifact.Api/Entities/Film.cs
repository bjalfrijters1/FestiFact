using System.Net;

namespace Festifact.Api.Entities
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Actors { get; set; }
    }
}
