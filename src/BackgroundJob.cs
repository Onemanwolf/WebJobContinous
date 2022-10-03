using Azure.Health.DataServices.Channels;
using Azure.Health.DataServices.Clients;
using Azure.Health.DataServices.Json;
using Azure.Health.DataServices.Security;
using Azure.Health.DataServices.Storage;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

using Microsoft.Extensions.Logging;
namespace src {
public class BackgroundJob
{

     private readonly IOptions<ServiceBusChannelOptions> serviceBusOptions;

        private IChannel channel;
        private readonly StorageLake storage;
        private readonly IAuthenticator authenticator;
        private string accessToken;
        private readonly ILogger logger;

BackgroundJob(ServiceConfig config, IAuthenticator authenticator = null, ILogger<BackgroundJob> logger = null){

}


[NoAutomaticTrigger]
public static void BackGroundWorkerFunction(
ILogger logger,
string value)
{

    while(true){

     var   message = value;
     Console.WriteLine(message);
    logger.LogInformation("Creating queue message: ", message);
    }

}
}
}