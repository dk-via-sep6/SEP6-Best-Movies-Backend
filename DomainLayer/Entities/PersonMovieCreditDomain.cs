namespace DomainLayer.Entities
{
    public class PersonMovieCreditDomain
    {
        public int PersonId { get; set; }
        public IReadOnlyList<PersonMovieCastMemberDomain> CastRoles { get; set; }
        public IReadOnlyList<PersonMovieCrewMemberDomain> CrewRoles { get; set; }
        public PersonMovieCreditDomain()
        {
            CastRoles = Array.Empty<PersonMovieCastMemberDomain>();
            CrewRoles = Array.Empty<PersonMovieCrewMemberDomain>();
        }
    }
}
