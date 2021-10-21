using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace StringCalculator.Api.HealthChecks
{
    public class LoggerHealthCheck : IHealthCheck
    {
        private readonly string path;

        public LoggerHealthCheck(string path)
        {
            this.path = path;
        }

        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, 
            CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                var logFileStream = File.OpenWrite(path);
                logFileStream.Close();
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
