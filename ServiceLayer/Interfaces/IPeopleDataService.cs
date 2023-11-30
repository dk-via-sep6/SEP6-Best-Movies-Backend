using DomainLayer.Entities;

namespace ServiceLayer.Interfaces
{
    public interface IPeopleDataService
    {
        Task<PersonDomain> FindByIdAsync(int personId);
        Task<List<PersonInfoDomain>> SearchByNameAsync(string name);
        Task<PersonMovieCreditDomain> GetMovieCreditsAsync(int personId);
        Task<PersonTVCreditDomain> GetTVCreditsAsync(int personId);
    }
}
