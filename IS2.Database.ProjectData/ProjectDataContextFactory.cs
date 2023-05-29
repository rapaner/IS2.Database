using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IS2.Database.ProjectData
{
    internal class ProjectDataContextFactory : IDesignTimeDbContextFactory<ProjectDataContext>
    {
        public ProjectDataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectDataContext>();
            optionsBuilder.UseNpgsql("Data Source=ProjectData.db");

            return new ProjectDataContext(optionsBuilder.Options);
        }
    }
}