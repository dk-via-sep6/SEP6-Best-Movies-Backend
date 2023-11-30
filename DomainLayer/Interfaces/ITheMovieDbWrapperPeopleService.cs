using DM.MovieApi.MovieDb.People;

namespace DomainLayer.Interfaces
{
    public interface ITheMovieDbWrapperPeopleService
    {
        Task<Person> FindByIdAsync(int personId);
        Task<List<PersonInfo>> SearchByNameAsync(string name);
        Task<PersonMovieCredit> GetMovieCreditsAsync(int personId);
        Task<PersonTVCredit> GetTVCreditsAsync(int personId);
    }
}
