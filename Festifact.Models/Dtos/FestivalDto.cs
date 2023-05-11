using Festifact.Models.Dtos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Festifact.Models.Dtos.Enums.Type;

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
        public string OrganiserName { get; set; }
    }
}
