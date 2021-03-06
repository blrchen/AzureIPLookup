﻿using AzureIpLookup.Providers;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(AzureIpLookup.Startup))]
namespace AzureIpLookup
{
    // This class is used for dependency injection setup when the functions runtime starts up.
    // Details see https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();
            builder.Services.AddLogging();
            builder.Services.AddMemoryCache();
            builder.Services.AddSingleton<IAzureIpInfoProvider, AzureIpInfoProvider>();
            builder.Services.AddSingleton<IAzureStorageProvider, AzureStorageProvider>();
            builder.Services.AddSingleton<IIpAddressProvider, IpAddressProvider>();
        }
    }
}
