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
    }
}
