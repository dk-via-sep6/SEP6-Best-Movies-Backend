using DM.MovieApi.MovieDb.Genres;

namespace DomainLayer.Entities
{
    public class MovieInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsAdultThemed { get; set; }
        public string BackdropPath { get; set; }
        public IReadOnlyList<Genre> Genres { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterPath { get; set; }
        public double Popularity { get; set; }
        public bool Video { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }
        public MovieInfo()
        {
            Genres = Array.Empty<Genre>();
            ReleaseDate = DateTime.UnixEpoch;
        }

        public override string ToString()
        {
            return $"{Title} ({Id} - {ReleaseDate:yyyy-MM-dd})";
        }

    }
}
