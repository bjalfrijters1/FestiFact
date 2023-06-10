using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festifact.Models.Dtos
{
    public class FestivalDto
    {
        public int Id { get; set; }
        public int OrganiserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Genre { get; set; }
        public int Type { get; set; }
        public byte[]? Banner { get; set; }
        public string? AgeCategory { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string OrganiserName { get; set; }
        public int TicketsRemaining { get; set; }
        public int MaxTickets { get; set; }
    }
}
