using IS2.Database.Common.Extensions;
using IS2.Database.Common.Repositories;
using IS2.Database.ConfigurationData;
using IS2.Database.ManagementData;
using IS2.Database.ManagementData.Model;
using Microsoft.Extensions.DependencyInjection;

namespace IS2.Database.Tests
{
    public class DependencyInjectionTests
    {
        [Fact]
        public void AddVersioningRepositories_Test()
        {
            var assembly = typeof(ConfigurationDataContext).Assembly;
            var services = new ServiceCollection();

            services.AddDbContext<ConfigurationDataContext>();
            services.AddVersioningRepositories(assembly);
            var repository = services.BuildServiceProvider().GetRequiredService<IVersioningRepository<AssignmentEntity, Guid>>();
        }
    }
}