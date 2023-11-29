namespace DomainLayer.Entities
{
    public class MovieCrewMember
    {
        public int PersonId { get; set; }
        public string CreditId { get; set; }
        public string Department { get; set; }
        public string Job { get; set; }
        public string Name { get; set; }
        public string ProfilePath { get; set; }
        public override string ToString()
        {
            return $"{Name} | {Department} | {Job}";
        }
    }
}
