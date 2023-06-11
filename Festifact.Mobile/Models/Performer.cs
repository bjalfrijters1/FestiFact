using Festifact.Mobile.Extensions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Festifact.Mobile.Extensions.Enums.Type;

namespace Festifact.Mobile.Models
{
    public class Performer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageFilePath { get; set; }
        public string CountryOfOrigin { get; set; }
        public Type Type { get; set; }
        public Genre Genre { get; set; }
    }
}
