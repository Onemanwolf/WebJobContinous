

using System.ComponentModel;
using Microsoft.Azure.WebJobs;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs;
using Microsoft.Azure.WebJobs.Extensions.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace src {
public class Program
{

private static ServiceConfig config;
    private async static Task Main(string[] args)
    {

// configuration
        IConfigurationBuilder cbuilder = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
                .AddEnvironmentVariables("AZURE_");
            IConfigurationRoot root = cbuilder.Build();
            config = new();
            root.Bind(config);

// webjob
       var builder = new HostBuilder();
    builder.UseEnvironment("development");
    builder.ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
                b.AddAzureStorage();
            });
    // dependency injection
    builder.ConfigureServices(s => s.AddSingleton(typeof(ServiceConfig), config));

    // host build and run
    var host = builder.Build();
    using (host)
    {


        var jobHost = host.Services.GetService(typeof(IJobHost)) as JobHost;
        await host.StartAsync();
        var inputs = new Dictionary<string, object>
        {
            { "value", "Hello world!" }
        };

        await jobHost.CallAsync(typeof(BackgroundJob).GetMethod("BackGroundWorkerFunction"), inputs);


}


}
}
}