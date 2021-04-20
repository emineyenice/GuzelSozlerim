using GuzelSozlerim.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuzelSozlerim
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //https://github.com/dotnet-architecture/eShopOnWeb/blob/master/src/Web/Program.cs

            var host = CreateHostBuilder(args).Build();
            //scope kendimiz istek oluþturduk
            using (var scope = host.Services.CreateScope())
            {
                //var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Kullanici>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                await DataSeed.SeedRollerVeKullanicilarAsync( roleManager, userManager);
                // DataSeed.SeedRolesAndUsers(dbContext,roleManager,userManager);
            }
            host.Run();
            //Run dan önce builden sonra scope acýyoruz ve seed modeli oluþturduk
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
