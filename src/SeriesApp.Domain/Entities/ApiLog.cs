using System;
using Volo.Abp.Domain.Entities;

namespace SeriesApp.Entities;

public class ApiLog : Entity<Guid>
{
    public DateTime RequestTime { get; set; }
    public string Endpoint { get; set; }
    public int ResponseTimeMs { get; set; }
    public bool IsSuccess { get; set; }
    public string ErrorMessage { get; set; }

    protected ApiLog() { }

    public ApiLog(Guid id, DateTime requestTime, string endpoint, int responseTimeMs, bool isSuccess, string errorMessage)
        : base(id)
    {
        RequestTime = requestTime;
        Endpoint = endpoint;
        ResponseTimeMs = responseTimeMs;
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }
}