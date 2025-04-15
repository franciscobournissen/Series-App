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
        public string Director { get; set; } // Nuevo
        public string Writer { get; set; } // Nuevo
        public string Cast { get; set; }
        public string Poster { get; set; }
        public string CountryOrigin { get; set; }
        public decimal RatingImdb { get; set; } // Cambia float a decimal para mayor precisión

        private Serie() { }

        public Serie(Guid id, string title, string genre, int duration, DateTime releaseDate,
            string director, string writer, string cast, string poster, string countryOrigin, decimal ratingImdb)
            : base(id)
        {
            Title = title;
            Genre = genre;
            Duration = duration;
            ReleaseDate = releaseDate;
            Director = director;
            Writer = writer;
            Cast = cast;
            Poster = poster;
            CountryOrigin = countryOrigin;
            RatingImdb = ratingImdb;
        }
    }
}