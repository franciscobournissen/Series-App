using System;
using System.Reflection.Metadata;
using Volo.Abp.Domain.Entities;

namespace SeriesApp.Entities;

public class Serie : AggregateRoot<Guid>
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public int Duration { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Director { get; set; }
    public string Writer { get; set; }
    public string Cast { get; set; }
    public string Poster { get; set; }
    public string Country { get; set; }
    public decimal ImdbRating { get; set; }

    protected Serie() { }

    public Serie(
        Guid id,
        string title,
        string genre,
        int duration,
        DateTime releaseDate,
        string director,
        string writer,
        string cast,
        string poster,
        string country,
        decimal imdbRating)
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
        Country = country;
        ImdbRating = imdbRating;
    }
}