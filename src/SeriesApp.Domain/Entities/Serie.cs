using System;
using System.Reflection.Metadata;
using Volo.Abp.Domain.Entities;

namespace SeriesApp.Entities
{
    public class Serie : AggregateRoot<Guid>
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Cast { get; set; }
        public Blob Poster { get; set; }
        public string CountryOrigin { get; set; }
        public float RatingImdb { get; set; }

        private Serie() {} 

        public Serie(Guid id, string title, string genre, int duration, DateTime releaseDate, string cast,
            Blob poster, string countryOrigin, float ratingimdb) : base(id)
        {
            Title = title;
            Genre = genre;
            ReleaseDate = releaseDate;
            Duration = duration;
            Cast = cast;
            Poster = poster;
            CountryOrigin = countryOrigin;
            RatingImdb = ratingimdb;
            
        }
    }
}