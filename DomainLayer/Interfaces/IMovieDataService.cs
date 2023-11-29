using DomainLayer.Entities;

namespace DomainLayer.Interfaces
{
    public interface IMovieDataService
    {
        Task<Movie> FindMovieByIdAsync(int id);

    }
}
