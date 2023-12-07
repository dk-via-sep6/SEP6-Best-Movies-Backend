namespace ServiceLayer.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterPath { get; set; }
        public bool IsAdultThemed { get; set; }
        public string BackdropPath { get; set; }
        public string OriginalLanguage { get; set; }
        public IReadOnlyList<GenreDTO> Genres { get; set; }
        public int Runtime { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }
        public double? WeightedRating { get; set; }
    }
}
