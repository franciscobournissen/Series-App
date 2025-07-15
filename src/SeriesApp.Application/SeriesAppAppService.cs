using System.Collections.Generic;
using System.Threading.Tasks;
using SeriesApp.Domain.Services;
using SeriesApp.Dtos;
using SeriesApp.Entities;
using Volo.Abp.Application.Services;
using Volo.Abp.ObjectMapping;
using SeriesApp.Dtos;

namespace SeriesApp;

public class SeriesAppService : ApplicationService, ISeriesAppService
{
    private readonly ISeriesApiService _seriesApiService;

    public SeriesAppService(ISeriesApiService seriesApiService)
    {
        _seriesApiService = seriesApiService;
    }

    public async Task<List<SeriesDto>> SearchSeriesAsync(SearchSeriesInput input)
    {
        var series = await _seriesApiService.SearchSeriesAsync(input.Title, input.Genre);
        return ObjectMapper.Map<List<Serie>, List<SeriesDto>>(series);
    }
}