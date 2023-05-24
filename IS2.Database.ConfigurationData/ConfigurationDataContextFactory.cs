using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IS2.Database.ConfigurationData
{
    internal class ConfigurationDataContextFactory : IDesignTimeDbContextFactory<ConfigurationDataContext>
    {
        public ConfigurationDataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ConfigurationDataContext>();
            optionsBuilder.UseNpgsql("Data Source=ConfigurationData.db");

            return new ConfigurationDataContext(optionsBuilder.Options);
        }
    }
}