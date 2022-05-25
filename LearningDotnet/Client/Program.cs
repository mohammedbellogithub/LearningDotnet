using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace LearningDotnet.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjQzNzYwQDMxMzkyZTM0MmUzMER6Uk15WEY0RmE1a1VZOHYrRE1PYjJGM3dsSS9GRGNWTzFvNWtMZnFpcms9;NjQzNzYxQDMxMzkyZTM0MmUzME1EU05lc2VaS0pqTnhnUDBSU3R0ME9rZnBYQ21WQjBteGFxU29DV1JBeVk9;NjQzNzYyQDMxMzkyZTM0MmUzME9ySm8rNzMxdjVydWJuNUhURVVlQ0Rnb3pyQ0dVOFVlNnI0cDJxOE1RNFU9;NjQzNzYzQDMxMzkyZTM0MmUzMFFwR2FBMmpUS3N0QWhyQ0hENVVQRVNId3hEdjNrckZacjBvVFQxUVhqaGc9;NjQzNzY0QDMxMzkyZTM0MmUzMGtpSlBOZXV5YmEvNTViKzhSY3F0THBIajJRODc5UEpNMFV0ZjZMTFY3dU09;NjQzNzY1QDMxMzkyZTM0MmUzMGRUbHR1VzMzVENpVEpLajg2L21QSjRDWmFKZFpBQ25GblpDaHFEbHdsSlE9;NjQzNzY2QDMxMzkyZTM0MmUzMExuWEhrVmdoY2lnbUNlN1pzVjNlc0ZqR0srTllZbGVjU2szNGhzUHJPeW89;NjQzNzY3QDMxMzkyZTM0MmUzMFNlWlJ4R2N6QVNicVZFcDhhUWpOZDQvWTh4WW93ZGJzanNZeHRKY2YvZ2s9;NjQzNzY4QDMxMzkyZTM0MmUzMGpnWmFNQTlPcTFkOUpEcFRzNTZZeDVETGJDQ3pUc1VnbTArUHdzdWl0NDA9;NjQzNzY5QDMxMzkyZTM0MmUzMGlmT3hXN1BoVmVuWi9lVU5yZ3d6TTZPVVJiMTFtbnhqNUdJVi8zTEVta1U9;NjQzNzcwQDMxMzkyZTM0MmUzMFk3c2lUSnZ3NW1BSHEvQzU2UXV2TWdpS2lvbjBHYmF3K1NmNGF0OXR1SkE9");
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSyncfusionBlazor();
            await builder.Build().RunAsync();
        }
    }
}
