using Festifact.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using Type = Festifact.Models.Enums.Type;

namespace Festifact.Api.Entities
{
    public class Festival
    {
        public int Id { get; set; }
        [ForeignKey("Organiser")]
        public int OrganiserId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Banner { get; set; }
        public Type Type { get; set; }
        public Genre Genre { get; set; }
        public string? AgeCategory { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<Location>? Locations { get; set; }
        public int MaxTickets { get; set; }
        public int TicketsRemaining { get; set; }
    }
}
