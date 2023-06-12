using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festifact.Models.Dtos
{
    public class FestivalPerformanceDto
    {
        public int Id { get; set; }
        public int FestivalId { get; set; }
        public int ShowId { get; set; }
        public string fName { get; set; }
        public string fDescription { get; set; }
        public string sName { get; set; }
        public string sDescription { get; set; }


    }
}
