using Library.IdentityServer.Data;
using Library.Server.Data;
using Library.Server.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IHost webHost =  CreateHostBuilder(args).Build();

            using  (var scope = webHost.Services.CreateScope())
            {
                IConfiguration configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

                AuthenticationContext authenticationContext = scope.ServiceProvider.GetRequiredService<AuthenticationContext>();
                ServerContext serverContext = scope.ServiceProvider.GetRequiredService<ServerContext>();

                var users = new List<User>();
                foreach (var user in authenticationContext.Users)
                {
                    users.Add(new User
                    {
                        Id = user.Id,
                        Name = user.UserName
                    });
                }

                var smallUsers = serverContext.Users.AsNoTracking().ToList();

                var results = users.Where(u => !smallUsers.Any(s => u.Id.Equals(s.Id) && u.Name.Equals(s.Name)));

                foreach (var user in results)
                {
                    serverContext.Users.Add(user);
                }

                await serverContext.SaveChangesAsync();
            }

            await webHost.RunAsync();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
