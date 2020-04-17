using Microsoft.Extensions.Configuration;
using MVVM.Model;
using System.IO;
using System.Threading.Tasks;

namespace MVVM.Core
{
    public class OwnerInfoService : IOwnerInfoService
    {
        public async Task<bool> IsOwnerAsync(OwnerInfo ownerInfo)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var configuredUserName = configuration.GetSection(Configuration.OwnerInfo)[Configuration.UserName];
            var configuredGreetingName = configuration.GetSection(Configuration.OwnerInfo)[Configuration.GreetingName];
            var configuredOwnerInfo = new OwnerInfo(configuredUserName, configuredGreetingName);

            await Task.Delay(5000).ConfigureAwait(false);

            var isOwner = configuredOwnerInfo.Equals(ownerInfo);
            return isOwner;
        }
    }
}
