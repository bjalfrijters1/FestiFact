using Festifact.Models.Enums;
using Org.BouncyCastle.Asn1.Cmp;
using Type = Festifact.Models.Enums.Type;

namespace Festifact.Mobile.Models
{
    public class Festival
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Type Type { get; set; }
        public Genre Genre { get; set; }
        public string Banner { get; set; }
        public string OrganiserName { get; set; }
        public int TicketsRemaining { get; set; }
        public string Address { get; set; } = "Hogeschoollaan 1 Breda";
        public double? Longitude { get; set; }
        public double? Latitutde { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double Distance { get; set; }
        public Location? FestivalLocation { get; set; }

        public override string ToString()
        {
            return "Name:" + Name + ", Description: " + Description;
        }
    }
}
