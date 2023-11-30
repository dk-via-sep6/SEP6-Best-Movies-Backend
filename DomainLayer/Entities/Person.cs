using DomainLayer.Enums;

namespace DomainLayer.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IReadOnlyList<string> AlsoKnownAs { get; set; }
        public bool IsAdultFilmStar { get; set; }
        public string Biography { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime? Deathday { get; set; }
        public Gender Gender { get; set; }
        public string Homepage { get; set; }
        public string ImdbId { get; set; }
        public string PlaceOfBirth { get; set; }
        public double Popularity { get; set; }
        public string ProfilePath { get; set; }
        public Person()
        {
            AlsoKnownAs = Array.Empty<string>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
