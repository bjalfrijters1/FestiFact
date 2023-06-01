using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festifact.Models.Dtos
{
    public class FilmDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Actors { get; set; }
    }
}
