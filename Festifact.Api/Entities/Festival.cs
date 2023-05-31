using Festifact.Api.Extensions.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using Type = Festifact.Api.Extensions.Enums.Type;

namespace Festifact.Api.Entities
{
    public class Festival
    {
        public int Id { get; set; }
        [ForeignKey("Organiser")]
        public int OrganiserId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<ImageUri> Images { get; set; } = new List<ImageUri>();
        public string? Banner { get; set; }
        public Type Type { get; set; }
        public Genre Genre { get; set; }
        public string? AgeCategory { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public List<Location>? Locations { get; set; }
    }
}
