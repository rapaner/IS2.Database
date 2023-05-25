using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IS2.Database.ManagementData
{
    internal class ManagementDataContextFactory : IDesignTimeDbContextFactory<ManagementDataContext>
    {
        public ManagementDataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ManagementDataContext>();
            optionsBuilder.UseNpgsql("Data Source=ManagementData.db");

            return new ManagementDataContext(optionsBuilder.Options);
        }
    }
}