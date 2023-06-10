using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festifact.Models.Dtos
{
    public class ShowToAddDto
    {
        public int LocationId { get; set; }
        public int? PerformerId { get; set; }
        public int? FilmId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageFilePath { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
