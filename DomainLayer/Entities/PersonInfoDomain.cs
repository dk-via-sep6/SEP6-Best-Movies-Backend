namespace DomainLayer.Entities
{
    public class PersonInfoDomain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAdultFilmStar { get; set; }
        public IReadOnlyList<PersonInfoRoleDomain> KnownFor { get; set; }
        public string ProfilePath { get; set; }
        public double Popularity { get; set; }
        public PersonInfoDomain()
        {
            KnownFor = Array.Empty<PersonInfoRoleDomain>();
        }

        public override string ToString()
        {
            return $"{Name} ({Id})";
        }
    }
}
