﻿using AutoMapper;
using DomainLayer.Entities;

using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class PersonDataService : IPersonDataService
    {
        private readonly IMapper _mapper;
        private readonly ITheMovieDbWrapperPersonService _peopleWrapperService;
        private readonly ITMdbPeopleService _peopleTmtbService;
        public PersonDataService(IMapper mapper, ITheMovieDbWrapperPersonService peopleWrapperService, ITMdbPeopleService peopleTmdbService)
        {
            _mapper = mapper;
            _peopleWrapperService = peopleWrapperService;
            _peopleTmtbService = peopleTmdbService;
        }
        public async Task<PersonDTO> FindByIdAsync(int personId)
        {
            var personData = await _peopleWrapperService.FindByIdAsync(personId);
            var domainPerson = _mapper.Map<PersonDomain>(personData);
            return _mapper.Map<PersonDTO>(domainPerson);
        }
        public async Task<PersonMovieCreditDTO> GetMovieCreditsAsync(int personId)
        {
            var personData = await _peopleWrapperService.GetMovieCreditsAsync(personId);
            var domainPerson = _mapper.Map<PersonMovieCreditDomain>(personData);
            return _mapper.Map<PersonMovieCreditDTO>(domainPerson);
        }
        public async Task<PersonTVCreditDomain> GetTVCreditsAsync(int personId)
        {
            var personData = await _peopleWrapperService.GetTVCreditsAsync(personId);
            return MapToDomainPersonTVCredit(personData);
        }
        public async Task<List<PersonInfoDTO>> SearchByNameAsync(string name)
        {
            var personData = await _peopleWrapperService.SearchByNameAsync(name);
            var domainPersonInfo = _mapper.Map<List<PersonInfoDomain>>(personData);

            var filteredAndSortedDomainPersonInfo = domainPersonInfo
           .Where(p => p.KnownFor != null && p.KnownFor.Any() && !string.IsNullOrWhiteSpace(p.Name) && p.Name.Trim().Length > 1)
           .OrderByDescending(p => p.Popularity)
           .ToList();

            return _mapper.Map<List<PersonInfoDTO>>(filteredAndSortedDomainPersonInfo);
        }
        public async Task<PeopleDTO> GetTrendingAsync()
        {
            var personData = await _peopleTmtbService.GetTrendingAsync();

            var peopleDto = new PeopleDTO
            {
                Page = personData.Page,
                Total_Pages = personData.Total_Pages,
                Total_Results = personData.Total_Results,
                Results = personData.Results.Select(MapToPersonResultDTO).ToList()
            };

            return peopleDto;
        }

        private PersonResultDTO MapToPersonResultDTO(PersonResultDomain person)
        {
            var topKnownForTitles = person.Known_For
                                        .OrderByDescending(k => k.Popularity)
                                        .Take(3)
                                        .Select(k => k.Title)
                                        .ToList();


            var combinedTitles = string.Join(", ", topKnownForTitles);

            return new PersonResultDTO
            {
                Id = person.Id,
                Name = person.Name,
                Profile_Path = person.Profile_Path,
                Popularity = person.Popularity,
                TopKnownForTitles = combinedTitles
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

    }
}
