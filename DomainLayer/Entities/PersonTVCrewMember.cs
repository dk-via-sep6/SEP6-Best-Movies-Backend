namespace DomainLayer.Entities
{
    public class PersonTVCrewMember
    {
        public int TVShowId { get; set; }
        public string CreditId { get; set; }
        public string Department { get; set; }
        public int EpisodeCount { get; set; }
        public DateTime FirstAirDate { get; set; }
        public string Job { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string PosterPath { get; set; }
    }
}
