using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace Festifact.Api.Entities
{
    /* LocationId and Start/End should ALWAYS be distinct & cannot overlap
     * Performer + LocationId + start/end is distinct as well.
     */
    public class Show
    {
        public int Id { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        [ForeignKey("Performer")]
        public int? PerformerId { get; set; }
        [ForeignKey("Film")]
        public int? FilmId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageFilePath { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
