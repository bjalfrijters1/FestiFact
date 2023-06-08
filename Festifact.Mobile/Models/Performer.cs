using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festifact.Mobile.Models
{
    public class Performer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageFilePath { get; set; }
        public string CountryOfOrigin { get; set; }
        public int Type { get; set; }
        public int Genre { get; set; }
    }
}
