using Blazored.LocalStorage;
using ColorPal.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace ColorPal
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBlazoredLocalStorageAsSingleton();
            builder.Services.AddSingleton<EventAggregator<string>>();
            builder.Services.AddSingleton<LocalStorageService>();
            builder.Services.AddSingleton<StateService>();

            await builder.Build().RunAsync();
        }
    }
}
