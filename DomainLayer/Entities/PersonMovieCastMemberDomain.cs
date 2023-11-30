namespace DomainLayer.Entities
{
    public class PersonMovieCastMemberDomain
    {
        public int MovieId { get; set; }
        public bool IsAdultThemed { get; set; }
        public string Character { get; set; }
        public string CreditId { get; set; }
        public string OriginalTitle { get; set; }
        public string PosterPath { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Title { get; set; }
    }
}
