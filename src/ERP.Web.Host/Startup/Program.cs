using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ERP.Web.Host.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseIIS()
                .UseStartup<Startup>()
                .Build();
        }
    }
}
