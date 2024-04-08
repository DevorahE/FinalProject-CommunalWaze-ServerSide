using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class WorkerService: BackgroundService
    {
        private const int generalDelay = 24 * 60 * 60 * 1000; // 24 hours in milliseconds 


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(generalDelay, stoppingToken);
                await DoBackupAsync();
            }
        }

        private static Task DoBackupAsync()
        {
           Dal.Repositories.ReportRepository.RemoveOldReports();
   
           return Task.FromResult("Done");
        }
    }
}
