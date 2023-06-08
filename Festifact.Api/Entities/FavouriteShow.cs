using System.ComponentModel.DataAnnotations.Schema;

namespace Festifact.Api.Entities
{
    public class FavouriteShow
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Show")]
        public int ShowId { get; set; }
    }
}
