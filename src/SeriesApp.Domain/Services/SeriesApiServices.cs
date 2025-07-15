using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Volo.Abp.Domain.Repositories;
using SeriesApp.Entities;
using Newtonsoft.Json;

namespace SeriesApp.Domain.Services;

public interface ISeriesApiService
{
    Task<List<Serie>> SearchSeriesAsync(string title, string genre);
}

public class SeriesApiService : ISeriesApiService
{
    private readonly IRepository<Serie, Guid> _serieRepository;
    private readonly IRepository<ApiLog, Guid> _apiLogRepository;
    private readonly HttpClient _httpClient;
    private readonly ILogger<SeriesApiService> _logger;

    public SeriesApiService(
        IRepository<Serie, Guid> serieRepository,
        IRepository<ApiLog, Guid> apiLogRepository,
        HttpClient httpClient,
        ILogger<SeriesApiService> logger)
    {
        _serieRepository = serieRepository;
        _apiLogRepository = apiLogRepository;
        _httpClient = httpClient;
        _logger = logger;
    }

public async Task<List<Serie>> SearchSeriesAsync(string title, string genre)
{
    _logger.LogInformation($"🔍 Iniciando búsqueda para Title: '{title}' | Genre: '{genre}'");

    var response = await _httpClient.GetAsync($"http://www.omdbapi.com/?s={Uri.EscapeDataString(title)}&type=series&apikey=e7ab7314");
    _logger.LogInformation($"🔗 Llamada a OMDb con resultado: {response.StatusCode}");

    var content = await response.Content.ReadAsStringAsync();
    _logger.LogInformation($"📦 Contenido crudo de OMDb: {content}");

    var searchResult = JsonConvert.DeserializeObject<OmdbSearchResponse>(content);
    if (searchResult?.Search == null)
    {
        throw new Exception("No se encontraron resultados para el título.");
    }

    var seriesList = new List<Serie>();

    foreach (var item in searchResult.Search)
    {
        var detailResp = await _httpClient.GetAsync($"http://www.omdbapi.com/?i={item.ImdbID}&apikey=e7ab7314");
        var detailContent = await detailResp.Content.ReadAsStringAsync();
        var detail = JsonConvert.DeserializeObject<OmdbSeriesResponse>(detailContent);

        if (!string.IsNullOrEmpty(genre) && !detail.Genre.ToLower().Contains(genre.ToLower()))
        {
            _logger.LogInformation($"❌ Serie '{detail.Title}' no coincide con el género '{genre}'");
            continue;
        }

        _logger.LogInformation($"✅ Serie válida encontrada: {detail.Title}");

        // Guardar en la base
        var serie = new Serie(
            id: Guid.NewGuid(),
            title: detail.Title,
            genre: detail.Genre,
            duration: int.TryParse(detail.Runtime?.Replace(" min", ""), out int duration) ? duration : 0,
            releaseDate: DateTime.TryParse(detail.Released, out DateTime releaseDate) ? releaseDate : DateTime.Now,
            director: detail.Director,
            writer: detail.Writer,
            cast: detail.Actors,
            poster: detail.Poster,
            country: detail.Country,
            imdbRating: decimal.TryParse(detail.ImdbRating, out decimal rating) ? rating : 0m
        );

        await _serieRepository.InsertAsync(serie);
        seriesList.Add(serie);
    }

    return seriesList;
}


}

public class OmdbSearchResponse
{
    public List<OmdbSearchItem> Search { get; set; }
    public string TotalResults { get; set; }
    public string Response { get; set; }
}

public class OmdbSearchItem
{
    public string Title { get; set; }
    public string Year { get; set; }
    public string ImdbID { get; set; }
    public string Type { get; set; }
    public string Poster { get; set; }
}

// Clase para deserializar la respuesta de OMDB
public class OmdbSeriesResponse
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Runtime { get; set; }
    public string Released { get; set; }
    public string Director { get; set; }
    public string Writer { get; set; }
    public string Actors { get; set; }
    public string Poster { get; set; }
    public string Country { get; set; }
    public string ImdbRating { get; set; }
    public string Response { get; set; }
}