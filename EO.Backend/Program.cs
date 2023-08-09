using EO.Backend.Services;

namespace EO.Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddGrpc();

            var app = builder.Build(); 

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();  

            app.UseStaticFiles();
            app.UseRouting();
            app.UseGrpcWeb();
            app.MapGrpcService<GreeterService>().EnableGrpcWeb();
            app.MapFallbackToFile("index.html");
         //   app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
           
            app.Run();
        }
    }
}