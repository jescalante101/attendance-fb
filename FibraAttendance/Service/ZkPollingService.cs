using FibraAttendance.Data;
using FibraAttendance.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FibraAttendance.Service
{
    public class ZkPollingService : IHostedService, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private Timer _timer;
        private const int PollingIntervalInMilliseconds = 5000;

        public ZkPollingService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(async (state) => await DoDatabaseWork(), null, TimeSpan.Zero, TimeSpan.FromMilliseconds(PollingIntervalInMilliseconds));
            return Task.CompletedTask;
        }

        private async Task DoDatabaseWork()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var zktecoService = scope.ServiceProvider.GetRequiredService<ZktecoDeviceService>(); // Instancia dentro del scope

                try
                {
                    var data = await dbContext.IclockTerminals.ToListAsync();
                    Console.WriteLine($"[{DateTime.Now}] Datos de la base de datos obtenidos: {data.Count}");

                    if (data != null)
                    {
                        foreach (var item in data)
                        {
                            if (item.Status != 1)
                            {
                                if (VerifyDevice(item.IpAddress, zktecoService)) // Pasa la instancia del servicio
                                {
                                    item.State = 1;
                                    await dbContext.SaveChangesAsync();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[{DateTime.Now}] Error al acceder a la base de datos: {ex.Message}");
                }
            }
        }

        private bool VerifyDevice(string ip, ZktecoDeviceService zktecoService)
        {
            int port = 4370;
            return zktecoService.Connect(ip, port);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}