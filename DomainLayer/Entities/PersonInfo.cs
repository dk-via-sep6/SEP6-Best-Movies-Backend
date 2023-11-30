namespace DomainLayer.Entities
{
    public class PersonInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAdultFilmStar { get; set; }
        public IReadOnlyList<PersonInfoRole> KnownFor { get; set; }
        public string ProfilePath { get; set; }
        public double Popularity { get; set; }
        public PersonInfo()
        {
            KnownFor = Array.Empty<PersonInfoRole>();
        }

        public override string ToString()
        {
            return $"{Name} ({Id})";
        }
    }
}
