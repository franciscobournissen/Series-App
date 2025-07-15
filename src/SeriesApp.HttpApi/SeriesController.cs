using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeriesApp.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace SeriesApp.Controllers;

[Route("api/series")]
[AllowAnonymous] // Requiere autenticación
public class SeriesController : AbpController
{
    private readonly ISeriesAppService _seriesAppService;

    public SeriesController(ISeriesAppService seriesAppService)
    {
        _seriesAppService = seriesAppService;
    }

    [HttpGet("search")]
    public async Task<List<SeriesDto>> SearchSeriesAsync([FromQuery] SearchSeriesInput input)

    {
        return await _seriesAppService.SearchSeriesAsync(input);
    }
}