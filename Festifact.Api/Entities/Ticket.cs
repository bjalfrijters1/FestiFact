using System.ComponentModel.DataAnnotations.Schema;

namespace Festifact.Api.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        [ForeignKey("Festival")]
        public int FestivalId { get; set; }
        public int? Rating { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
