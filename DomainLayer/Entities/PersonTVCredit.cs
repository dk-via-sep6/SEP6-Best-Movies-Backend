namespace DomainLayer.Entities
{
    public class PersonTVCredit
    {

        public int PersonId { get; set; }
        public IReadOnlyList<PersonTVCastMember> CastRoles { get; set; }
        public IReadOnlyList<PersonTVCrewMember> CrewRoles { get; set; }

        public PersonTVCredit()
        {
            CastRoles = Array.Empty<PersonTVCastMember>();
            CrewRoles = Array.Empty<PersonTVCrewMember>();
        }
    }
}
