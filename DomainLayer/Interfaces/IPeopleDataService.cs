using DomainLayer.Entities;

namespace DomainLayer.Interfaces
{
    public interface IPeopleDataService
    {
        Task<Person> FindByIdAsync(int personId);
        Task<List<PersonInfo>> SearchByNameAsync(string name);
        Task<PersonMovieCredit> GetMovieCreditsAsync(int personId);
        Task<PersonTVCredit> GetTVCreditsAsync(int personId);
    }
}
