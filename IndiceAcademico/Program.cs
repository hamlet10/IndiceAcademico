using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndiceAcademico.Models;
using IndiceAcademico.Persistence;
using IndiceAcademico.Persistence.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IndiceAcademico
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            CreateDbIfNotExist(host);
            host.Run();
        }

        private static void CreateDbIfNotExist(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                try
                {
                    var context = service.GetRequiredService<AcademicDBContext>();
                    var authDBContext = service.GetRequiredService<AuthDBContext>();
                    authDBContext.Database.Migrate();
                    context.Database.Migrate();
                    AuthInitializer.Initialize(authDBContext);
                    DBInitializer.Initialize(context);
                }
                catch (System.Exception)
                {

                    throw;
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
