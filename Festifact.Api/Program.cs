using Festifact.Api.Data;
using Festifact.Api.Repositories;
using Festifact.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/*builder.Services.AddSingleton<Festifact.Api.Repositories.Contracts.IFestivalRepository, Festifact.Api.Repositories.FestivalRepository>();
builder.Services.AddSingleton<Festifact.Api.Repositories.Contracts.IOrganiserRepository, Festifact.Api.Repositories.OrganiserRepository>();*/
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<FestifactDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FestifactConnection"))
);

builder.Services.AddScoped<IFestivalRepository, FestivalRepository>();
builder.Services.AddScoped<IOrganiserRepository, OrganiserRepository>();
builder.Services.AddScoped<IShowRepository, ShowRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IPerformerRepository, PerformerRepository>();
builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<IFestivalPerformanceRepository, FestivalPerformanceRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IFavouritePerformerRepository, FavouritePerformerRepository>();
builder.Services.AddScoped<IFavouriteShowRepository, FavouriteShowRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
    policy.WithOrigins("http://localhost:5094", "https://localhost:7224", "https://localhost:5094")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
