namespace ServiceLayer.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IReadOnlyList<string> AlsoKnownAs { get; set; }
        public bool IsAdultFilmStar { get; set; }
        public string Biography { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime? Deathday { get; set; }
        public GenderDTO Gender { get; set; }
        public string PlaceOfBirth { get; set; }
        public double Popularity { get; set; }
        public string ProfilePath { get; set; }
        public PersonDTO()
        {
            AlsoKnownAs = Array.Empty<string>();
        }
    }
}
