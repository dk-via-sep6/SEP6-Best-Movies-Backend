namespace ServiceLayer.DTOs
{
    public class MovieCreditDTO
    {
        public int MovieId { get; set; }
        public IReadOnlyList<MovieCastMemberDTO> CastMembers { get; set; }
        public IReadOnlyList<MovieCrewMemberDTO> CrewMembers { get; set; }
    }
}
