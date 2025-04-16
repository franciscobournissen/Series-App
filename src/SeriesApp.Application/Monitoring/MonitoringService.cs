using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using SeriesApp.Entities;

namespace SeriesApp.Application.Monitoring;

public class MonitoringService : ApplicationService
{
    private readonly IRepository<ApiLog, Guid> _apiLogRepository;

    public MonitoringService(IRepository<ApiLog, Guid> apiLogRepository)
    {
        _apiLogRepository = apiLogRepository;
    }

    public async Task<ApiMonitoringStatsDto> GetApiStatsAsync()
    {
        var logs = await _apiLogRepository.GetListAsync();
        return new ApiMonitoringStatsDto
        {
            TotalRequests = logs.Count,
            AverageResponseTimeMs = logs.Any() ? (int)logs.Average(l => l.ResponseTimeMs) : 0,
            ErrorCount = logs.Count(l => !l.IsSuccess)
        };
    }
}

public class ApiMonitoringStatsDto
{
    public int TotalRequests { get; set; }
    public int AverageResponseTimeMs { get; set; }
    public int ErrorCount { get; set; }
}