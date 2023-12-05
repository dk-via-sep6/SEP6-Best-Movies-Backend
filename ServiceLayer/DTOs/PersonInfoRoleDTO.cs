namespace ServiceLayer.DTOs
{
    public class PersonInfoRoleDTO
    {
        public int Id { get; set; }
        public MediaTypeDTO MediaType { get; set; }
        public string TVShowName { get; set; }
        public string TVShowOriginalName { get; set; }
        public string MovieTitle { get; set; }
        public string MovieOriginalTitle { get; set; }
        public string BackdropPath { get; set; }
        public string PosterPath { get; set; }
        public DateTime MovieReleaseDate { get; set; }
        public DateTime TVShowFirstAirDate { get; set; }
        public string Overview { get; set; }
        public bool IsAdultThemed { get; set; }
        public bool IsVideo { get; set; }
        public IReadOnlyList<GenreDTO> Genres { get; set; }
        public string OriginalLanguage { get; set; }
        public double Popularity { get; set; }
        public int VoteCount { get; set; }
        public double VoteAverage { get; set; }
        public IReadOnlyList<string> OriginCountry { get; set; }

        public PersonInfoRoleDTO()
        {
            Genres = Array.Empty<GenreDTO>();
            OriginCountry = Array.Empty<string>();
        }
    }
}
