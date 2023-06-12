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
        public string FName { get; set; }
        public string FDescription { get; set; }
        public string SName { get; set; }
        public string SDecription { get; set; }


    }
}
