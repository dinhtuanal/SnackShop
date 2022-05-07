using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DbContext
{
    public class SnackShopDbContextFactory : IDesignTimeDbContextFactory<SnackShopDbContext>
    {
        public SnackShopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<SnackShopDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new SnackShopDbContext(optionsBuilder.Options);
        }
    }
}
