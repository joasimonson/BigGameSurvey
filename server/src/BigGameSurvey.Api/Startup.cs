using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BigGameSurvey.Api.Contexts;
using BigGameSurvey.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

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

            services.AddCors();

            ConfigureMapping(services);
            ConfigureSwagger(services);
        }

        private void ConfigureMapping(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(EntityToDTOProfile));
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            
            services.AddSwaggerGen(opt => {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API ASP.NET Core",
                    Description = "API ASP.NET Core",
                    Contact = new OpenApiContact
                    {
                        Name = "Jô Araújo",
                        Url = new Uri("https://github.com/joasimonson/BigGameSurvey")
                    }
                });
                //opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    In = ParameterLocation.Header,
                //    Description = "Entre com o Token JWT",
                //    Name = "Authorization",
                //    Type = SecuritySchemeType.ApiKey,
                //});

                //opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "Bearer"
                //            },
                //        },
                //        Array.Empty<string>()
                //    }
                //});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(opt => {
                opt.RoutePrefix = "swagger";
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "API ASP.NET Core");
            });

            var options = new RewriteOptions();
            options.AddRedirect("^$", "swagger");
            app.UseRewriter(options);

            app.UseCors(opt => opt.AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
