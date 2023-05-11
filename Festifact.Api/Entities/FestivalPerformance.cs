using System.ComponentModel.DataAnnotations.Schema;

namespace Festifact.Api.Entities
{
    public class FestivalPerformance
    {
        public int Id { get; set; }
        public int FestivalId { get; set; }
        public int ShowId { get; set; }

        [ForeignKey("FestivalId")]
        public Festival Festival { get; set; }
      
        [ForeignKey("ShowId")]
        public Show Show { get; set; }
    }
}
