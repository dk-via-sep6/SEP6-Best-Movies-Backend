namespace DomainLayer.Entities
{
    public class PersonTVCastMember
    {
        public int TVShowId { get; set; }
        public string Character { get; set; }
        public string CreditId { get; set; }
        public int EpisodeCount { get; set; }
        public DateTime FirstAirDate { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string PosterPath { get; set; }
    }
}
