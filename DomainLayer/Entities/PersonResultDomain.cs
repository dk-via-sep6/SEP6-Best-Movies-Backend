namespace DomainLayer.Entities
{
    public class PersonResultDomain
    {
        public bool Adult { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Original_Name { get; set; }
        public string Media_Type { get; set; }
        public double Popularity { get; set; }
        public int Gender { get; set; }
        public string Known_For_Department { get; set; }
        public string Profile_Path { get; set; }
        public List<KnownForDomain> Known_For { get; set; }
    }
}
