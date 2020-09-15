using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigGameSurvey.Api.Contexts;
using BigGameSurvey.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BigGameSurvey.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string databaseUrl = Configuration["DATABASE_URL"];

            if (String.IsNullOrWhiteSpace(databaseUrl))
            {
                string connectionBase = Configuration.GetConnectionString("DefaultConnection");
                string host = Configuration["DBHOST"];
                string port = Configuration["DBPORT"];
                string db = Configuration["DBNAME"];
                string user = Configuration["DBUSER"];
                string pwd = Configuration["DBPASSWORD"];

                string connection = String.Format(connectionBase, host, port, db, user, pwd);
                Console.WriteLine(connection);
                services.AddDbContext<ApiContext>(options => options.UseNpgsql(connection));
            }
            else
            {
                var builder = new PostgreSqlConnectionStringBuilder(databaseUrl)
                {
                    Pooling = true,
                    TrustServerCertificate = true,
                    SslMode = SslMode.Require
                };

                services.AddDbContext<ApiContext>(options => options.UseNpgsql(builder.ConnectionString));
            }

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
