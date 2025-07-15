using System.Collections.Generic;
using System.Threading.Tasks;
using SeriesApp.Dtos;
using Volo.Abp.Application.Services;

namespace SeriesApp;

public interface ISeriesAppService : IApplicationService
{
    Task<List<SeriesDto>> SearchSeriesAsync(SearchSeriesInput input);
}