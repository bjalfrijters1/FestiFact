using Festifact.Models.Enums;
using Type = Festifact.Models.Enums.Type;

namespace Festifact.Api.Entities
{
    public class Performer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageFilePath { get; set; }
        public string CountryOfOrigin { get; set; }
        public Type Type { get; set; }
        public Genre Genre { get; set; }

    }
}
