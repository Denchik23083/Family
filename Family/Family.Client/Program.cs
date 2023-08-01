using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Family.Http.ChildrenHttpService;
using Family.Http.GenusHttpService;
using Family.Http.ParentsHttpService;

namespace Family.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<IParentsHttpService, ParentsHttpService>();
            builder.Services.AddScoped<IChildrenHttpService, ChildrenHttpService>();
            builder.Services.AddScoped<IGenusHttpService, GenusHttpService>();

            await builder.Build().RunAsync();
        }
    }
}
