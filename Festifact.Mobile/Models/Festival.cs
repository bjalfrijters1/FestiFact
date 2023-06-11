using Festifact.Mobile.Extensions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Type = Festifact.Mobile.Extensions.Enums.Type;

namespace Festifact.Mobile.Models
{
    public class Festival
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Type Type { get; set; }
        public Genre Genre { get; set; }
        public string OrganiserName { get; set; }
        public int TicketsRemaining { get; set; }

        public override string ToString()
        {
            return "Name:" + Name + ", Description: " + Description;
        }
    }
}
