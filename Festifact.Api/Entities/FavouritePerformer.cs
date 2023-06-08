using System.ComponentModel.DataAnnotations.Schema;

namespace Festifact.Api.Entities
{
    public class FavouritePerformer
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Performer")]
        public int PerformerId { get; set; }
    }
}
