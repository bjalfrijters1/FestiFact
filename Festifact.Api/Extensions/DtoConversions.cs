using Festifact.Api.Entities;
using Festifact.Models.Dtos;
using System.Runtime.CompilerServices;

namespace Festifact.Api.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<FestivalDto> ConvertToDto(this IEnumerable<Festival> festivals, IEnumerable<Organiser> organisers)
        {
            return (from festival in festivals
                    join organiser in organisers
                    on festival.OrganiserId equals organiser.Id
                    select new FestivalDto
                    {
                        Id = festival.Id,
                        OrganiserId = festival.OrganiserId,
                        Name = festival.Name,
                        Description = festival.Description,
                        Genre = (int)festival.Genre,
                        Type = (int)festival.Type,
                        OrganiserName = organiser.Name
                    }).ToList();

        }

        public static FestivalDto ConvertToDto(this Festival festival, Organiser organiser)
        {
            return new FestivalDto
            {
                Id = festival.Id,
                OrganiserId = festival.OrganiserId,
                Name = festival.Name,
                Description = festival.Description,
                Genre = (int)festival.Genre,
                Type = (int)festival.Type,
                OrganiserName = organiser.Name
            };
        }

        public static ShowDto ConvertToDto(this Show show, Film? film, Performer? performer, Location location)
        {
            if (film != null) 
            {
                return new ShowDto
                {
                    Id = show.Id,
                    LocationId = location.Id,
                    PerformerId = null,
                    FilmId = film.Id,
                    Name = show.Name,
                    Description = show.Description,
                    ImageFilePath = show.ImageFilePath,
                    StartDateTime = show.StartDateTime,
                    EndDateTime = show.EndDateTime,
                    LocationName = location.Name,
                    PerformerName = null,
                    FilmName = film.Name
                };
            } else
            {
                return new ShowDto
                {
                    Id = show.Id,
                    LocationId = location.Id,
                    PerformerId = performer.Id,
                    FilmId = null,
                    Name = show.Name,
                    Description = show.Description,
                    ImageFilePath = show.ImageFilePath,
                    StartDateTime = show.StartDateTime,
                    EndDateTime = show.EndDateTime,
                    LocationName = location.Name,
                    PerformerName = performer.Name,
                    FilmName = null
                };
            }
        }

        public static IEnumerable<ShowDto> ConvertToDto(this IEnumerable<Show> shows, IEnumerable<Location> locations, IEnumerable<Performer> performers, IEnumerable<Film> films)
        {
            List<ShowDto> a = new List<ShowDto>();
                              a.AddRange(from show in shows
                              join location in locations
                              on show.LocationId equals location.Id
                              join performer in performers
                              on show.PerformerId equals performer.Id
                              select new ShowDto
                              {
                                  Id = show.Id,
                                  LocationId = location.Id,
                                  PerformerId = performer.Id,
                                  FilmId = null,
                                  Name = show.Name,
                                  Description = show.Description,
                                  ImageFilePath = show.ImageFilePath,
                                  StartDateTime = show.StartDateTime,
                                  EndDateTime = show.EndDateTime,
                                  LocationName = location.Name,
                                  PerformerName = performer.Name,
                                  FilmName = null
                              });

            List<ShowDto> b = new List<ShowDto>();
            b.AddRange(from show in shows
                       join location in locations
                       on show.LocationId equals location.Id
                       join film in films
                       on show.FilmId equals film.Id
                       select new ShowDto
                       {
                           Id = show.Id,
                           LocationId = location.Id,
                           PerformerId = null,
                           FilmId = film.Id,
                           Name = show.Name,
                           Description = show.Description,
                           ImageFilePath = show.ImageFilePath,
                           StartDateTime = show.StartDateTime,
                           EndDateTime = show.EndDateTime,
                           LocationName = location.Name,
                           PerformerName = null,
                           FilmName = film.Name
                       });
            a.AddRange(b);
            return a;
        }

        public static IEnumerable<FestivalPerformanceDto> ConvertToDto(this IEnumerable<FestivalPerformance> fps, Festival festival, IEnumerable<Show> shows)
        {
            return (from fp in fps
                    join show in shows
                    on fp.ShowId equals show.Id
                    select new FestivalPerformanceDto
                    {
                        Id = fp.Id,
                        FestivalId = festival.Id,
                        ShowId = show.Id,
                        fName = festival.Name,
                        fDescription = festival.Description,
                        sName = show.Name,
                        sDescription = show.Description
                    }).ToList();
        }

        public static FestivalPerformanceDto ConvertToDto(this FestivalPerformance fp, Festival festival, Show show)
        {
            return new FestivalPerformanceDto
            {
                Id = fp.Id,
                FestivalId = festival.Id,
                ShowId = show.Id,
                fName = festival.Name,
                fDescription = festival.Description,
                sName = show.Name,
                sDescription = show.Description
            };
        }
    }
}
