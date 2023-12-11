namespace DomainLayer.Entities
{
    public class PeopleDomain
    {
        public int Page { get; set; }
        public List<PersonResultDomain> Results { get; set; }
        public int Total_Pages { get; set; }
        public int Total_Results { get; set; }
    }
}
