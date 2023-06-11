using Festifact.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Festifact.Models.Enums.Type;

namespace Festifact.Models.Dtos
{
    public class FestivalDto
    {
        public int Id { get; set; }
        public int OrganiserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public Type Type { get; set; }
        public string? Banner { get; set; }
        public string? AgeCategory { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string OrganiserName { get; set; }
        public int TicketsRemaining { get; set; }
        public int MaxTickets { get; set; }
    }
}
