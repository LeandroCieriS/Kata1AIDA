using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace StringCalculator.Api.HealthChecks
{
    public class LoggerHealthCheck : IHealthCheck
    {
        private readonly string dirPath;

        public LoggerHealthCheck(string dirPath)
        {
            this.dirPath = dirPath;
        }

        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, 
            CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                CheckAccessToDirectory();
                return Task.FromResult(
                    HealthCheckResult.Healthy("Can write on directory."));
            }
            catch
            {
                return Task.FromResult(
                    new HealthCheckResult(context.Registration.FailureStatus,
                        "Can not write on directory."));
            }
        }

        private void CheckAccessToDirectory()
        {
            File.Create(
                Path.Combine(
                    dirPath,
                    Path.GetRandomFileName()
                ),
                1,
                FileOptions.DeleteOnClose);
        }
    }
}
