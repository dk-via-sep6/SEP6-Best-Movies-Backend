using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Enums;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class PersonDataService : IPersonDataService
    {
        private readonly IMapper _mapper;
        private readonly ITheMovieDbWrapperPersonService _peopleService;
        public PersonDataService(IMapper mapper, ITheMovieDbWrapperPersonService peopleService)
        {
            _mapper = mapper;
            _peopleService = peopleService;
        }
        public async Task<PersonDTO> FindByIdAsync(int personId)
        {
            var personData = await _peopleService.FindByIdAsync(personId);
            var domainPerson = _mapper.Map<PersonDomain>(personData);
            return _mapper.Map<PersonDTO>(domainPerson);
        }
        public async Task<PersonMovieCreditDomain> GetMovieCreditsAsync(int personId)
        {
            var personData = await _peopleService.GetMovieCreditsAsync(personId);
            return MapToDomainPersonMovieCredit(personData);
        }
        public async Task<PersonTVCreditDomain> GetTVCreditsAsync(int personId)
        {
            var personData = await _peopleService.GetTVCreditsAsync(personId);
            return MapToDomainPersonTVCredit(personData);
        }
        public async Task<List<PersonInfoDomain>> SearchByNameAsync(string name)
        {
            var apiResponse = await _peopleService.SearchByNameAsync(name);
            return apiResponse.Select(MapToDomainPersonInfo).ToList();
        }
        private PersonDomain MapToDomainPerson(DM.MovieApi.MovieDb.People.Person personData)
        {
            return new PersonDomain
            {
                Id = personData.Id,
                Name = personData.Name,
                AlsoKnownAs = personData.AlsoKnownAs,
                Biography = personData.Biography,
                Birthday = personData.Birthday,
                Deathday = personData.Deathday,
                Gender = MapToDomainGender(personData.Gender),
                Homepage = personData.Homepage,
                ImdbId = personData.ImdbId,
                PlaceOfBirth = personData.PlaceOfBirth,
                Popularity = personData.Popularity,
                ProfilePath = personData.ProfilePath,
            };
        }
        private PersonMovieCreditDomain MapToDomainPersonMovieCredit(DM.MovieApi.MovieDb.People.PersonMovieCredit personData)
        {
            return new PersonMovieCreditDomain
            {
                PersonId = personData.PersonId,
                CastRoles = MapToDomainPersonMovieCastMember(personData.CastRoles),
                CrewRoles = MapToDomainPersonMovieCrewMember(personData.CrewRoles),
            };
        }
        private PersonTVCreditDomain MapToDomainPersonTVCredit(DM.MovieApi.MovieDb.People.PersonTVCredit personData)
        {
            return new PersonTVCreditDomain
            {
                PersonId = personData.PersonId,
                CastRoles = MaptoDomainPersonTvCastMember(personData.CastRoles),
                CrewRoles = MapToDomainPersonTvCrewMember(personData.CrewRoles),

            };
        }
        private PersonInfoDomain MapToDomainPersonInfo(DM.MovieApi.MovieDb.People.PersonInfo apiPersonInfo)
        {
            return new PersonInfoDomain
            {
                Id = apiPersonInfo.Id,
                Name = apiPersonInfo.Name,
                IsAdultFilmStar = apiPersonInfo.IsAdultFilmStar,
                KnownFor = MapToDomainPersonInfoRoles(apiPersonInfo.KnownFor),
                ProfilePath = apiPersonInfo.ProfilePath,
                Popularity = apiPersonInfo.Popularity
            };
        }
        private GenderDomain MapToDomainGender(DM.MovieApi.MovieDb.People.Gender apiGender)
        {
            switch (apiGender)
            {
                case DM.MovieApi.MovieDb.People.Gender.Male:
                    return GenderDomain.Male;
                case DM.MovieApi.MovieDb.People.Gender.Female:
                    return GenderDomain.Female;
                default:
                    return GenderDomain.Unknown;
            }
        }
        private MediaTypeDomain MapToDomainMediaType(DM.MovieApi.MovieDb.People.MediaType apiMediaType)
        {
            switch (apiMediaType)
            {
                case DM.MovieApi.MovieDb.People.MediaType.Movie:
                    return MediaTypeDomain.Movie;
                case DM.MovieApi.MovieDb.People.MediaType.TV:
                    return MediaTypeDomain.Movie;
                default:
                    return MediaTypeDomain.Unknown;

            }
        }
        private IReadOnlyList<PersonMovieCastMemberDomain> MapToDomainPersonMovieCastMember(IReadOnlyList<DM.MovieApi.MovieDb.People.PersonMovieCastMember> personData)
        {
            return personData.Select(m => new PersonMovieCastMemberDomain
            {
                MovieId = m.MovieId,
                IsAdultThemed = m.IsAdultThemed,
                Character = m.Character,
                CreditId = m.CreditId,
                OriginalTitle = m.OriginalTitle,
                PosterPath = m.PosterPath,
                ReleaseDate = m.ReleaseDate,
                Title = m.Title
            }).ToList();

        }
        private IReadOnlyList<PersonMovieCrewMemberDomain> MapToDomainPersonMovieCrewMember(IReadOnlyList<DM.MovieApi.MovieDb.People.PersonMovieCrewMember> personData)
        {
            return personData.Select(c => new PersonMovieCrewMemberDomain
            {
                MovieId = c.MovieId,
                IsAdultThemed = c.IsAdultThemed,
                CreditId = c.CreditId,
                Department = c.Department,
                Job = c.Job,
                OriginalTitle = c.OriginalTitle,
                PosterPath = c.PosterPath,
                ReleaseDate = c.ReleaseDate,
                Title = c.Title
            }).ToList();

        }
        private IReadOnlyList<PersonTVCastMemberDomain> MaptoDomainPersonTvCastMember(IReadOnlyList<DM.MovieApi.MovieDb.People.PersonTVCastMember> personData)
        {
            return personData.Select(m => new PersonTVCastMemberDomain
            {
                TVShowId = m.TVShowId,
                Character = m.Character,
                CreditId = m.CreditId,
                EpisodeCount = m.EpisodeCount,
                FirstAirDate = m.FirstAirDate,
                Name = m.Name,
                OriginalName = m.OriginalName,
                PosterPath = m.PosterPath,
            }).ToList();
        }
        private IReadOnlyList<PersonTVCrewMemberDomain> MapToDomainPersonTvCrewMember(IReadOnlyList<DM.MovieApi.MovieDb.People.PersonTVCrewMember> personData)
        {
            return personData.Select(m => new PersonTVCrewMemberDomain
            {
                TVShowId = m.TVShowId,
                CreditId = m.CreditId,
                Department = m.Department,
                EpisodeCount = m.EpisodeCount,
                FirstAirDate = m.FirstAirDate,
                Job = m.Job,
                Name = m.Name,
                OriginalName = m.OriginalName,
                PosterPath = m.PosterPath,
            }).ToList();
        }
        private IReadOnlyList<PersonInfoRoleDomain> MapToDomainPersonInfoRoles(IReadOnlyList<DM.MovieApi.MovieDb.People.PersonInfoRole> personData)
        {
            return personData.Select(m => new PersonInfoRoleDomain
            {
                Id = m.Id,
                MediaType = MapToDomainMediaType(m.MediaType),
                TVShowName = m.TVShowName,
                TVShowOriginalName = m.TVShowOriginalName,
                MovieTitle = m.MovieTitle,
                MovieOriginalTitle = m.MovieOriginalTitle,
                BackdropPath = m.BackdropPath,
                PosterPath = m.PosterPath,
                MovieReleaseDate = m.MovieReleaseDate,
                TVShowFirstAirDate = m.TVShowFirstAirDate,
                Overview = m.Overview,
                IsAdultThemed = m.IsAdultThemed,
                IsVideo = m.IsVideo,
                Genres = MapToDomainGenres(m.Genres),
                OriginalLanguage = m.OriginalLanguage,
                Popularity = m.Popularity,
                VoteCount = m.VoteCount,
                VoteAverage = m.VoteAverage,
                OriginCountry = m.OriginCountry.ToList()
            }).ToList();
        }
        private IReadOnlyList<GenreDomain> MapToDomainGenres(IReadOnlyList<DM.MovieApi.MovieDb.Genres.Genre> apiGenres)
        {
            return apiGenres.Select(g => new GenreDomain
            {
                Id = g.Id,
                Name = g.Name
            }).ToList();
        }
    }
}
