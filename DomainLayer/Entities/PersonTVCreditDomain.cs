namespace DomainLayer.Entities
{
    public class PersonTVCreditDomain
    {

        public int PersonId { get; set; }
        public IReadOnlyList<PersonTVCastMemberDomain> CastRoles { get; set; }
        public IReadOnlyList<PersonTVCrewMemberDomain> CrewRoles { get; set; }

        public PersonTVCreditDomain()
        {
            CastRoles = Array.Empty<PersonTVCastMemberDomain>();
            CrewRoles = Array.Empty<PersonTVCrewMemberDomain>();
        }
    }
}
