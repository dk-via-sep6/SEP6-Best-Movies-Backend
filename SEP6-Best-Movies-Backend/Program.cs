using AutoMapper;
using DataAccessLayer.DbContextFolder;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repository;
using DM.MovieApi.MovieDb.Genres;
using DM.MovieApi.MovieDb.Movies;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

var builder = WebApplication.CreateBuilder(args);

// AutoMapper Configuration
var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<MovieDomain, MovieDTO>();
    cfg.CreateMap<Movie, MovieDomain>();
    cfg.CreateMap<Genre, GenreDomain>();
    cfg.CreateMap<MovieInfo, MovieInfoDomain>();
    cfg.CreateMap<MovieInfoDomain, MovieDTO>();
    cfg.CreateMap<MovieCredit, MovieCreditDomain>();
    cfg.CreateMap<MovieCreditDomain, MovieCreditDTO>();
    cfg.CreateMap<MovieCastMember, MovieCastMemberDomain>();
    cfg.CreateMap<MovieCrewMember, MovieCrewMemberDomain>();
    cfg.CreateMap<MovieCastMemberDomain, MovieCastMemberDTO>();
    cfg.CreateMap<MovieCrewMemberDomain, MovieCrewMemberDTO>();
    cfg.CreateMap<UserDTO, UserDomain>();
    cfg.CreateMap<UserDomain, UserDTO>();

    // Add mappings for Comment
    cfg.CreateMap<CommentDomain, CommentDTO>();
    cfg.CreateMap<CommentDTO, CommentDomain>();
});
IMapper mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);

// Add services to the container.
builder.Services.AddControllers();

var bearerToken = builder.Configuration["MovieApi:BearerToken"];
builder.Services.AddSingleton<ITheMovieDbWrapperMovieService>(_ => new TheMovieDbWrapperMovieService(bearerToken));
builder.Services.AddSingleton<ITheMovieDbWrapperPeopleService>(_ => new TheMovieDbWrapperPeopleService(bearerToken));

// Register your MovieDataService
builder.Services.AddScoped<IMovieDataService, MovieDataService>();
builder.Services.AddScoped<IPeopleDataService, PeopleDataService>();
builder.Services.AddScoped<IUserDataService, UserDataService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Register Comment related services
builder.Services.AddScoped<ICommentDataService, CommentDataService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

// CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000") // Replace with the actual origin of your frontend app
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

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
