using DomainLayer.Entities;
using ServiceLayer.DTOs;

namespace ServiceLayer.Interfaces
{
    public interface IPersonDataService
    {
        Task<PersonDTO> FindByIdAsync(int personId);
        Task<List<PersonInfoDTO>> SearchByNameAsync(string name);
        Task<PersonMovieCreditDTO> GetMovieCreditsAsync(int personId);
        Task<PersonTVCreditDomain> GetTVCreditsAsync(int personId);
        Task<PeopleDTO> GetTrendingAsync();
    }
}
