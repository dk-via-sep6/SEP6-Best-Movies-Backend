using DM.MovieApi.MovieDb.Movies;

namespace DomainLayer.Entities
{
    public class MovieCredit
    {
        public int MovieId { get; set; }
        public IReadOnlyList<MovieCastMember> CastMembers { get; set; }
        public IReadOnlyList<MovieCrewMember> CrewMembers { get; set; }
    }
}
