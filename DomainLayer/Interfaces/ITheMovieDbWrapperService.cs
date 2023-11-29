using DM.MovieApi.MovieDb.Movies;

namespace DomainLayer.Interfaces
{
    public interface ITheMovieDbWrapperService
    {
        Task<Movie> FindMovieByIdAsync(int movieId);
    }
}
