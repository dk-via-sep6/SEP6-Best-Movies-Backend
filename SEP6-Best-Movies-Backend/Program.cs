using AutoMapper;
using DataAccessLayer.DbContextFolder;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
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

// AutoMapper Configuration
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
    cfg.CreateMap<PersonMovieCredit, PersonMovieCreditDomain>();
    cfg.CreateMap<PersonMovieCreditDomain, PersonMovieCreditDTO>();
    cfg.CreateMap<PersonMovieCastMember, PersonMovieCastMemberDomain>();
    cfg.CreateMap<PersonMovieCastMemberDomain, PersonMovieCastMemberDTO>();
    cfg.CreateMap<PersonMovieCrewMember, PersonMovieCrewMemberDomain>();
    cfg.CreateMap<PersonMovieCrewMemberDomain, PersonMovieCrewMemberDTO>();
    cfg.CreateMap<PersonInfo, PersonInfoDomain>();
    cfg.CreateMap<PersonInfoDomain, PersonInfoDTO>();
    cfg.CreateMap<PersonInfoRole, PersonInfoRoleDomain>();
    cfg.CreateMap<PersonInfoRoleDomain, PersonInfoRoleDTO>();

    cfg.CreateMap<CommentDomain, CommentDTO>();
    cfg.CreateMap<CommentDTO, CommentDomain>();

    cfg.CreateMap<RatingDomain, RatingDTO>();
    cfg.CreateMap<RatingDTO, RatingDomain>();
    cfg.CreateMap<RatingDTO, RatingDomain>();

    cfg.CreateMap<WatchlistDomain, WatchlistDTO>();
    cfg.CreateMap<WatchlistDTO, WatchlistDomain>();
});
IMapper mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);

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

// Register Comment related services
builder.Services.AddScoped<ICommentDataService, CommentDataService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddScoped<IRatingDataService, RatingDataService>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();

builder.Services.AddScoped<IWatchlistDataService, WatchlistDataService>();
builder.Services.AddScoped<IWatchlistRepository, WatchlistRepository>();

// CORS Policy

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("https://sep6-best-movies-frontend.azurewebsites.net") // Replace with the actual origin of your frontend app
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});


var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");


// Swagger/OpenAPI configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        connectionString,
        x => x.MigrationsAssembly("DataAccessLayer")
    ));

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
