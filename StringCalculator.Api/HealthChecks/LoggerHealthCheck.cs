using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace StringCalculator.Api.HealthChecks
{
    public class LoggerHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, 
            CancellationToken cancellationToken = new CancellationToken())
        {
            const string path = "../Logs/log.txt";
            try
            {
                var fs = File.OpenWrite(path);
                return Task.FromResult(
                    HealthCheckResult.Healthy("Logger can be written on."));
            }
            catch
            {
                return Task.FromResult(
                    new HealthCheckResult(context.Registration.FailureStatus,
                        "Can not write on Log."));
            }
        }
    }
}
