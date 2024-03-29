﻿using Festifact.Api.Entities;
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
                        Genre = festival.Genre,
                        Type = festival.Type,
                        Banner = festival.Banner,
                        StartDate = festival.StartDate,
                        EndDate = festival.EndDate,
                        MaxTickets = festival.MaxTickets,
                        TicketsRemaining = festival.TicketsRemaining,
                        OrganiserName = organiser.Name,
                        Latitude = festival.Latitude,
                        Longitude = festival.Longitude,
                        Address = festival.Address
                    }).ToList();

        }

        public static FestivalDto ConvertToDto(this Festival festival)
        {
            return new FestivalDto
            {
                Id = festival.Id,
                Name = festival.Name,
                Description = festival.Description,
                Banner = festival.Banner,
                Genre = festival.Genre,
                Type = festival.Type,
                StartDate = festival.StartDate,
                EndDate = festival.EndDate,
                MaxTickets = festival.MaxTickets,
                TicketsRemaining = festival.TicketsRemaining,
                Latitude = festival.Latitude,
                Longitude = festival.Longitude,
                Address = festival.Address
            };
        }

        public static FestivalDto ConvertToDto(this Festival festival, Organiser organiser)
        {
            return new FestivalDto
            {
                Id = festival.Id,
                OrganiserId = festival.OrganiserId,
                Name = festival.Name,
                Description = festival.Description,
                Banner = festival.Banner,
                Genre = festival.Genre,
                Type = festival.Type,
                OrganiserName = organiser.Name,
                MaxTickets = festival.MaxTickets,
                TicketsRemaining = festival.TicketsRemaining,
                Latitude = festival.Latitude,
                Longitude = festival.Longitude,
                Address = festival.Address
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

        public static IEnumerable<ShowDto> ConvertToDto(this IEnumerable<Show> shows, IEnumerable<Location> locations, IEnumerable<Performer> performers, IEnumerable<Film>? films)
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
            if (shows != null)
            {
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
            }
            return a;
        }

        public static IEnumerable<FestivalPerformanceDto> ConvertToDto(this IEnumerable<FestivalPerformance> fps, Festival festival, IEnumerable<Show> shows)
        {
            return (from fp in fps
                    join show in shows
                    on fp.ShowId equals show.Id
                    where fp.FestivalId == festival.Id
                    select new FestivalPerformanceDto
                    {
                        Id = fp.Id,
                        FestivalId = festival.Id,
                        ShowId = fp.Id,
                        FName = festival.Name,
                        FDescription = festival.Description,
                        SName = show.Name,
                        SDecription = show.Description
                    }).ToList();
        }

        public static FestivalPerformanceDto ConvertToDto(this FestivalPerformance fp, Festival festival, Show show)
        {
            return new FestivalPerformanceDto
            {
                Id = fp.Id,
                FestivalId = festival.Id,
                ShowId = show.Id,
                FName = festival.Name,
                FDescription = festival.Description,
                SName = show.Name,
                SDecription = show.Description
            };
        }

        public static FilmDto ConvertToDto(this Film film)
        {
            return new FilmDto
            {
                Id = film.Id,
                Name = film.Name,
                Description = film.Description,
                Director = film.Director,
                Year = film.Year,
                CountryOfOrigin = film.CountryOfOrigin,
                Actors = film.Actors
            };
        }

        public static IEnumerable<FilmDto> ConvertToDto(this IEnumerable<Film> films) 
        {
            return (from film in films
                    select new FilmDto
                    {
                        Id = film.Id,
                        Name = film.Name,
                        Description = film.Description,
                        Director = film.Director,
                        Year = film.Year,
                        CountryOfOrigin = film.CountryOfOrigin,
                        Actors = film.Actors
                    });
        }

        public static PerformerDto ConvertToDto(this Performer performer)
        {
            return new PerformerDto
            {
                Id = performer.Id,
                Name = performer.Name,
                Description = performer.Description,
                ImageFilePath = performer.ImageFilePath,
                CountryOfOrigin = performer.CountryOfOrigin,
                Type = (int)performer.Type,
                Genre = (int)performer.Genre
            };
        }

        public static IEnumerable<PerformerDto> ConvertToDto(this IEnumerable<Performer> performers)
        {
            return (from performer in performers
                    select new PerformerDto
                    {
                        Id = performer.Id,
                        Name = performer.Name,
                        Description = performer.Description,
                        ImageFilePath = performer.ImageFilePath,
                        CountryOfOrigin = performer.CountryOfOrigin,
                        Type = (int)performer.Type,
                        Genre = (int)performer.Genre
                    });
        }

        public static IEnumerable<TicketDto> ConvertToDto(this IEnumerable<Ticket> tickets, Festival festival)
        {
            return (from ticket in tickets
                    select new TicketDto
                    {
                        Id = ticket.Id,
                        FestivalId = festival.Id,
                    }).ToList();
        }

        public static TicketDto ConvertToDto(this Ticket ticket)
        {
            return new TicketDto
            {
                Id = ticket.Id,
                FestivalId = ticket.FestivalId
            };
        }

        public static UserDto ConvertToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Address = user.Address
            };
        }

        public static FavouriteShowDto ConvertToDto(this FavouriteShow favouriteShow)
        {
            return new FavouriteShowDto
            {
                Id = favouriteShow.Id,
                UserId = favouriteShow.UserId,
                ShowId = favouriteShow.ShowId
            };
        }

        public static FavouritePerformerDto ConvertToDto(this FavouritePerformer favouritePerformer)
        {
            return new FavouritePerformerDto
            {
                Id = favouritePerformer.Id,
                UserId = favouritePerformer.UserId,
                PerformerId = favouritePerformer.PerformerId
            };
        }

        public static LocationDto ConvertToDto(this Location location)
        {
            return new LocationDto
            {
                Id = location.Id,
                Name = location.Name,
                Capacity = location.Capacity
            };
        }

        public static IEnumerable<LocationDto> ConvertToDto(this IEnumerable<Location> locations)
        {
            return (from location in locations
                    select new LocationDto
                    {
                        Id = location.Id,
                        Name = location.Name,
                        Capacity = location.Capacity
                    });
        }
    }
}
