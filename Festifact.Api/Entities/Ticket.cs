using System.ComponentModel.DataAnnotations.Schema;

namespace Festifact.Api.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public int FestivalId { get; set; }
        public int? Rating { get; set; }
        public bool? IsAvailable { get; set; }

        [ForeignKey("FestivalId")]
        public Festival Festival { get; set; }
    }
}
