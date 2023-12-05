﻿using DomainLayer.Entities;
using ServiceLayer.DTOs;

namespace ServiceLayer.Interfaces
{
    public interface IPersonDataService
    {
        Task<PersonDTO> FindByIdAsync(int personId);
        Task<List<PersonInfoDomain>> SearchByNameAsync(string name);
        Task<PersonMovieCreditDomain> GetMovieCreditsAsync(int personId);
        Task<PersonTVCreditDomain> GetTVCreditsAsync(int personId);
    }
}