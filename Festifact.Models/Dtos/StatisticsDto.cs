using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festifact.Models.Dtos
{
    public class StatisticsDto
    {
        public int FestivalId { get; set; }
        public int TicketsSold { get; set; }
        public int TicketsAvailable { get; set; }
        //public int rating {get; set;}

    }
}
