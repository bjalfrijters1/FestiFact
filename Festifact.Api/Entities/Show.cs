using System.ComponentModel.DataAnnotations.Schema;

namespace Festifact.Api.Entities
{
    /* LocationId and Start/End should ALWAYS be distinct & cannot overlap
     * Performer + LocationId + start/end is distinct as well.
     */
    public class Show
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int? PerformerId { get; set; }
        public int? FilmId { get; set; }
        public string Description { get; set; }
        public string? ImageFilePath { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        [ForeignKey("PerformerId")]
        public Performer Performer { get; set; }

        [ForeignKey("FilmId")]
        public Film Film{ get; set; }
    }
}
