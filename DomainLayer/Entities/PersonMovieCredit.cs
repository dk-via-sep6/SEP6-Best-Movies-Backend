namespace DomainLayer.Entities
{
    public class PersonMovieCredit
    {
        public int PersonId { get; set; }
        public IReadOnlyList<PersonMovieCastMember> CastRoles { get; set; }
        public IReadOnlyList<PersonMovieCrewMember> CrewRoles { get; set; }
        public PersonMovieCredit()
        {
            CastRoles = Array.Empty<PersonMovieCastMember>();
            CrewRoles = Array.Empty<PersonMovieCrewMember>();
        }
    }
}
