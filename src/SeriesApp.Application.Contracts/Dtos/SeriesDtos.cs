using System;
using Volo.Abp.Application.Dtos;

namespace SeriesApp.Dtos;

public class SeriesDto : EntityDto<Guid>
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
}

public class SearchSeriesInput
{
    public string? Title { get; set; }
    public string? Genre { get; set; }
}