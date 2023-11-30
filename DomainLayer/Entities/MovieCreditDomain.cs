using DM.MovieApi.MovieDb.Movies;

namespace DomainLayer.Entities
{
    public class MovieCreditDomain
    {
        public int MovieId { get; set; }
        public IReadOnlyList<MovieCastMemberDomain> CastMembers { get; set; }
        public IReadOnlyList<MovieCrewMemberDomain> CrewMembers { get; set; }
    }
}
