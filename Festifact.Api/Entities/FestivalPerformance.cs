using System.ComponentModel.DataAnnotations.Schema;

namespace Festifact.Api.Entities
{
    public class FestivalPerformance
    {
        public int Id { get; set; }
        [ForeignKey("Festival")]
        public int FestivalId { get; set; }
        [ForeignKey("Show")]
        public int ShowId { get; set; }
    }
}
