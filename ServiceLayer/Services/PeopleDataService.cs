using DomainLayer.Entities;
using DomainLayer.Enums;
using DomainLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class PeopleDataService : IPeopleDataService
    {
        private ITheMovieDbWrapperPeopleService _peopleService;
        public PeopleDataService(ITheMovieDbWrapperPeopleService peopleService)
        {
            _peopleService = peopleService;
        }
        public async Task<Person> FindByIdAsync(int personId)
        {
            var personData = await _peopleService.FindByIdAsync(personId);
            return MapToDomainPerson(personData);
        }
        public async Task<PersonMovieCredit> GetMovieCreditsAsync(int personId)
        {
            var personData = await _peopleService.GetMovieCreditsAsync(personId);
            return MapToDomainPersonMovieCredit(personData);
        }
        public async Task<PersonTVCredit> GetTVCreditsAsync(int personId)
        {
            var personData = await _peopleService.GetTVCreditsAsync(personId);
            return MapToDomainPersonTVCredit(personData);
        }
        public async Task<List<PersonInfo>> SearchByNameAsync(string name)
        {
            var apiResponse = await _peopleService.SearchByNameAsync(name);
            return apiResponse.Select(MapToDomainPersonInfo).ToList();
        }
        private Person MapToDomainPerson(DM.MovieApi.MovieDb.People.Person personData)
        {
            return new Person
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
        private PersonMovieCredit MapToDomainPersonMovieCredit(DM.MovieApi.MovieDb.People.PersonMovieCredit personData)
        {
            return new PersonMovieCredit
            {
                PersonId = personData.PersonId,
                CastRoles = MapToDomainPersonMovieCastMember(personData.CastRoles),
                CrewRoles = MapToDomainPersonMovieCrewMember(personData.CrewRoles),
            };
        }
        private PersonTVCredit MapToDomainPersonTVCredit(DM.MovieApi.MovieDb.People.PersonTVCredit personData)
        {
            return new PersonTVCredit
            {
                PersonId = personData.PersonId,
                CastRoles = MaptoDomainPersonTvCastMember(personData.CastRoles),
                CrewRoles = MapToDomainPersonTvCrewMember(personData.CrewRoles),

            };
        }
        private PersonInfo MapToDomainPersonInfo(DM.MovieApi.MovieDb.People.PersonInfo apiPersonInfo)
        {
            return new PersonInfo
            {
                Id = apiPersonInfo.Id,
                Name = apiPersonInfo.Name,
                IsAdultFilmStar = apiPersonInfo.IsAdultFilmStar,
                KnownFor = MapToDomainPersonInfoRoles(apiPersonInfo.KnownFor),
                ProfilePath = apiPersonInfo.ProfilePath,
                Popularity = apiPersonInfo.Popularity
            };
        }
        private Gender MapToDomainGender(DM.MovieApi.MovieDb.People.Gender apiGender)
        {
            switch (apiGender)
            {
                case DM.MovieApi.MovieDb.People.Gender.Male:
                    return Gender.Male;
                case DM.MovieApi.MovieDb.People.Gender.Female:
                    return Gender.Female;
                default:
                    return Gender.Unknown;
            }
        }
        private MediaType MapToDomainMediaType(DM.MovieApi.MovieDb.People.MediaType apiMediaType)
        {
            switch (apiMediaType)
            {
                case DM.MovieApi.MovieDb.People.MediaType.Movie:
                    return MediaType.Movie;
                case DM.MovieApi.MovieDb.People.MediaType.TV:
                    return MediaType.Movie;
                default:
                    return MediaType.Unknown;

            }
        }
        private IReadOnlyList<PersonMovieCastMember> MapToDomainPersonMovieCastMember(IReadOnlyList<DM.MovieApi.MovieDb.People.PersonMovieCastMember> personData)
        {
            return personData.Select(m => new PersonMovieCastMember
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
        private IReadOnlyList<PersonMovieCrewMember> MapToDomainPersonMovieCrewMember(IReadOnlyList<DM.MovieApi.MovieDb.People.PersonMovieCrewMember> personData)
        {
            return personData.Select(c => new PersonMovieCrewMember
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
        private IReadOnlyList<PersonTVCastMember> MaptoDomainPersonTvCastMember(IReadOnlyList<DM.MovieApi.MovieDb.People.PersonTVCastMember> personData)
        {
            return personData.Select(m => new PersonTVCastMember
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
        private IReadOnlyList<PersonTVCrewMember> MapToDomainPersonTvCrewMember(IReadOnlyList<DM.MovieApi.MovieDb.People.PersonTVCrewMember> personData)
        {
            return personData.Select(m => new PersonTVCrewMember
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
        private IReadOnlyList<PersonInfoRole> MapToDomainPersonInfoRoles(IReadOnlyList<DM.MovieApi.MovieDb.People.PersonInfoRole> personData)
        {
            return personData.Select(m => new PersonInfoRole
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
        private IReadOnlyList<Genre> MapToDomainGenres(IReadOnlyList<DM.MovieApi.MovieDb.Genres.Genre> apiGenres)
        {
            return apiGenres.Select(g => new Genre
            {
                Id = g.Id,
                Name = g.Name
            }).ToList();
        }
    }
}
