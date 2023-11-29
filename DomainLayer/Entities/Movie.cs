using DM.MovieApi.MovieDb;
using DM.MovieApi.MovieDb.Collections;
using DM.MovieApi.MovieDb.Companies;
using DM.MovieApi.MovieDb.Genres;
using DM.MovieApi.MovieDb.Keywords;

namespace DomainLayer.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterPath { get; set; }
        public bool IsAdultThemed { get; set; }
        public string BackdropPath { get; set; }
        public CollectionInfo MovieCollectionInfo { get; set; }
        public int Budget { get; set; }
        public IReadOnlyList<Genre> Genres { get; set; }
        public string Homepage { get; set; }
        public string ImdbId { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public double Popularity { get; set; }
        public IReadOnlyList<ProductionCompanyInfo> ProductionCompanies { get; set; }
        public IReadOnlyList<Country> ProductionCountries { get; set; }
        public decimal Revenue { get; set; }
        public int Runtime { get; set; }
        public IReadOnlyList<Language> SpokenLanguages { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public bool IsVideo { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }
        public IReadOnlyList<Keyword> Keywords { get; set; }

        public Movie()
        {
            Genres = Array.Empty<Genre>();
            Keywords = Array.Empty<Keyword>();
            ProductionCompanies = Array.Empty<ProductionCompanyInfo>();
            ProductionCountries = Array.Empty<Country>();
            SpokenLanguages = Array.Empty<Language>();
        }
    }
}
