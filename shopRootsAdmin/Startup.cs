using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopRoots.infrastructure.extensions;
using shopRoots.infrastructure.helpers;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using shopRoots.infrastructure.mappings.autoMapper;
using shopRootsAdmin.core.interfaces;
using shopRoots.infrastructure.services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

namespace shopRootsAdmin
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


            try
            {
                services.AddControllers();
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "shopRootsAdmin", Version = "v1" });
                });
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                services.AddScoped(typeof(DbContext), typeof(dbHelper));
                services.AddDependencies();
                services.AddDbContext<dbHelper>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                //services.AddDatabaseDeveloperPageExceptionFilter();
                services.AddControllersWithViews();
                var mapperConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new autoMapper());
                });

                IMapper mapper = mapperConfig.CreateMapper();
                services.AddSingleton(mapper);
                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = Configuration["Jwt:Issuer"],
                            ValidAudience = Configuration["Jwt:Issuer"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                        };
                    });
        }
            catch (Exception)
            {

                throw;
            }


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "shopRootsAdmin v1"));
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
