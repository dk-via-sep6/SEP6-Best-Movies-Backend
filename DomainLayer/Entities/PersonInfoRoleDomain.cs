﻿using DomainLayer.Enums;

namespace DomainLayer.Entities
{
    public class PersonInfoRoleDomain
    {
        public int Id { get; set; }
        public MediaTypeDomain MediaType { get; set; }
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
        public IReadOnlyList<GenreDomain> Genres { get; set; }
        public string OriginalLanguage { get; set; }
        public double Popularity { get; set; }
        public int VoteCount { get; set; }
        public double VoteAverage { get; set; }
        public IReadOnlyList<string> OriginCountry { get; set; }

        public PersonInfoRoleDomain()
        {
            Genres = Array.Empty<GenreDomain>();
            OriginCountry = Array.Empty<string>();
        }

        public override string ToString()
        {
            if (MediaType == MediaTypeDomain.Movie)
            {
                return $"Movie: {MovieTitle} ({Id} - {MovieReleaseDate:yyyy-MM-dd})";
            }

            return $"TV: {TVShowName} ({Id} - {TVShowFirstAirDate:yyyy-MM-dd})";
        }
    }
}
