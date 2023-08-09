using EO.Protos;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components;
using System.Threading.Channels;
using System.ServiceModel.Channels;

namespace EO.Web
{
    public class Program
    {
     //   private static readonly Grpc.Net.Client channel;

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddSingleton(services =>
            {

                ChannelBase channel = null;
                //ChannelBase channel = null;
                return new Greeter.GreeterClient(channel);
            });

            await builder.Build().RunAsync();
        }
    }
}