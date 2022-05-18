using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStore.SQL;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext dbContext)
        {
            Console.WriteLine("--> Trying to apply migrations...");

            try
            {
                dbContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Migrations could not applied: {ex.Message}");
            }
        }
    }
}