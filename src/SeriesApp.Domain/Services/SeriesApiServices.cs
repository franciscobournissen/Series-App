using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Volo.Abp.Domain.Repositories;
using SeriesApp.Entities;

namespace SeriesApp.Domain.Services;

public interface ISeriesApiService
{
    Task<Serie> SearchSeriesAsync(string title, string genre);
}

public class SeriesApiService : ISeriesApiService
{
    private readonly IRepository<ApiLog, Guid> _apiLogRepository;
    private readonly HttpClient _httpClient;
    private readonly ILogger<SeriesApiService> _logger;

    public SeriesApiService(
        IRepository<ApiLog, Guid> apiLogRepository,
        HttpClient httpClient,
        ILogger<SeriesApiService> logger)
    {
        _apiLogRepository = apiLogRepository;
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<Serie> SearchSeriesAsync(string title, string genre)
    {
        var stopwatch = Stopwatch.StartNew();
        var requestTime = DateTime.UtcNow;
        bool isSuccess = false;
        string errorMessage = null;

        try
        {
            _logger.LogInformation("Calling OMDB API for title: {Title}", title);
            var response = await _httpClient.GetAsync($"http://www.omdbapi.com/?t={title}&type=series&apikey=e7ab7314");
            response.EnsureSuccessStatusCode();
            isSuccess = true;

            var serie = new Serie(Guid.NewGuid(), title, genre, 0, DateTime.Now, "", "", "", "", "", 0m);
            return serie;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error calling OMDB API for title: {Title}", title);
            errorMessage = ex.Message;
            throw;
        }
        finally
        {
            stopwatch.Stop();
            var apiLog = new ApiLog(
                Guid.NewGuid(),
                requestTime,
                $"GET /?t={title}&type=series",
                (int)stopwatch.ElapsedMilliseconds,
                isSuccess,
                errorMessage
            );
            await _apiLogRepository.InsertAsync(apiLog);
        }
    }
}