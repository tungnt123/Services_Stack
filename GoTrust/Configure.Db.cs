using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using System;

namespace GoTrust
{
   //  Example Data Model
    
    public class ConfigureDb : IConfigureServices, IConfigureAppHost
    {
        IConfiguration Configuration { get; }
        public ConfigureDb(IConfiguration configuration) => Configuration = configuration;

        public void Configure(IServiceCollection services)
        {
            services.AddSingleton<IDbConnectionFactory>(new OrmLiteConnectionFactory(
                Configuration.GetConnectionString("DefaultConnection")
                    ?? "Test_sqlite",
                SqliteDialect.Provider));
        }

        public void Configure(IAppHost appHost)
        {
            appHost.GetPlugin<SharpPagesFeature>()?.ScriptMethods.Add(new DbScriptsAsync());

         //   Create non-existing Table and add Seed Data Example
             using var db = appHost.Resolve<IDbConnectionFactory>().Open();
            if (db.CreateTableIfNotExists<ServiceModel.Models.dto_Test>())
            {
                //db.Insert(new MyTable { Name = "Seed Data for new MyTable" });
            }
        }
    }
}
