using AutoMapper;
using DataAccessLayer.DbContextFolder;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repository;
using DM.MovieApi.MovieDb.Genres;
using DM.MovieApi.MovieDb.Movies;
using DM.MovieApi.MovieDb.People;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

var builder = WebApplication.CreateBuilder(args);


var config = new MapperConfiguration(cfg =>
{   //Movie Mappings 
    cfg.CreateMap<Movie, MovieDomain>();
    cfg.CreateMap<MovieDomain, MovieDTO>();
    cfg.CreateMap<Genre, GenreDomain>();
    cfg.CreateMap<GenreDomain, GenreDTO>();
    cfg.CreateMap<MovieInfo, MovieInfoDomain>();
    cfg.CreateMap<MovieInfoDomain, MovieDTO>();
    cfg.CreateMap<MovieCredit, MovieCreditDomain>();
    cfg.CreateMap<MovieCreditDomain, MovieCreditDTO>();
    cfg.CreateMap<MovieCastMember, MovieCastMemberDomain>();
    cfg.CreateMap<MovieCastMemberDomain, MovieCastMemberDTO>();
    cfg.CreateMap<MovieCrewMember, MovieCrewMemberDomain>();
    cfg.CreateMap<MovieCrewMemberDomain, MovieCrewMemberDTO>();

    //User Mappings
    cfg.CreateMap<UserDTO, UserDomain>();
    cfg.CreateMap<UserDomain, UserDTO>();


    //Person Mappings
    cfg.CreateMap<Person, PersonDomain>();
    cfg.CreateMap<PersonDomain, PersonDTO>();

    // Add other mappings here
});
IMapper mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
// Add services to the container.

builder.Services.AddControllers();

var bearerToken = builder.Configuration["MovieApi:BearerToken"];
builder.Services.AddSingleton<ITheMovieDbWrapperMovieService>(_ => new TheMovieDbWrapperMovieService(bearerToken));
builder.Services.AddSingleton<ITheMovieDbWrapperPersonService>(_ => new TheMovieDbWrapperPersonService(bearerToken));

// Register your MovieDataService
builder.Services.AddScoped<IMovieDataService, MovieDataService>();
builder.Services.AddScoped<IPersonDataService, PersonDataService>();
builder.Services.AddScoped<IUserDataService, UserDataService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        connectionString, // Use the connectionString variable directly
        x => x.MigrationsAssembly("DataAccessLayer") // Specify the migrations assembly here
    ));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowSpecificOrigin");



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
