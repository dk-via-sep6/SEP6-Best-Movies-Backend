namespace ServiceLayer.DTOs
{
    public class PersonMovieCreditDTO
    {
        public int PersonId { get; set; }
        public IReadOnlyList<PersonMovieCastMemberDTO> CastRoles { get; set; }
        public IReadOnlyList<PersonMovieCrewMemberDTO> CrewRoles { get; set; }
        public PersonMovieCreditDTO()
        {
            CastRoles = Array.Empty<PersonMovieCastMemberDTO>();
            CrewRoles = Array.Empty<PersonMovieCrewMemberDTO>();
        }
    }
}
