using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festifact.Models.Dtos
{
    public class FestivalToAddDto
    {
        public int OrganiserId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public byte[]? Banner { get; set; }
        public int Type { get; set; }
        public int Genre { get; set; }
        public string? AgeCategory { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MaxTickets { get; set; }
        public int TicketsRemaining { get; set; }
    }
}
