using Festifact.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Festifact.Api.Data
{
    public class FestifactDbContext:DbContext
    {
        public FestifactDbContext(DbContextOptions<FestifactDbContext> options) : base(options) 
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Organiser
            modelBuilder.Entity<Organiser>().HasData(new Organiser
            {
                Id = 1,
                Name = "foo"
            });

            //Festival
            modelBuilder.Entity<Festival>().HasData(new Festival
            {
                Id = 1,
                OrganiserId = 1,
                Name = "bar",
                Description = "baz",
                Type = 0,
                Genre = 0

            });

            modelBuilder.Entity<Location>().HasData(new Location
            {
                Id = 1,
                Capacity = 1000,
                Name = "My backyard"
            });

            modelBuilder.Entity<Performer>().HasData(new Performer
            {
                Id = 1,
                Name = "Coolio",
                Description = "Coolino",
                Type = 0,
                Genre = 0,
                CountryOfOrigin = "Iceland"
            });

            //placeholder film
            modelBuilder.Entity<Film>().HasData(new Film
            {
                Id = 1,
                Name = "Placeholder",
                Description = "Empty",
                Director = "Not available",
                Year = 0,
                CountryOfOrigin = "LaLaLand",
                Actors = "Fairies"
            });

            //Show
            modelBuilder.Entity<Show>().HasData(new Show
            {
                Id = 1,
                LocationId = 1,
                PerformerId = 1,
                FilmId = 1,
                Description = "Show by Coolio",
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now.AddHours(2)
            });

            //Add show to festival
            modelBuilder.Entity<FestivalPerformance>().HasData(new FestivalPerformance
            {
                Id = 1,
                FestivalId = 1,
                ShowId = 1
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Piet",
                Address = "Hogeschoollaan 1",
                Email = "piet@test.nl",
                DateOfBirth = DateTime.Now.AddYears(-20)
            });

            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                Id = 1,
                FestivalId = 1
            });
        }

        public DbSet<Festival> Festivals { get; set; }
        public DbSet<Organiser> Organisers { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<FestivalPerformance> FestivalPerformances { get;set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
