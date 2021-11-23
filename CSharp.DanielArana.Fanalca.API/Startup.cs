
using CSharp.DanielArana.Fanalca.BL.Interfaces.Security;
using CSharp.DanielArana.Fanalca.BL;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.DanielArana.Fanalca.BL.Imp.Security;
using CSharp.DanielArana.Fanalca.API.Data;
using CSharp.DanielArana.Fanalca.Entities.Security;
using CSharp.DanielArana.Fanalca.DAL;
using Microsoft.EntityFrameworkCore;
using CSharp.DanielArana.Fanalca.BL.Interfaces;
using CSharp.DanielArana.Fanalca.DAL.Connention;
using CSharp.DanielArana.Fanalca.BL.Imp.Fanalca;
using CSharp.DanielArana.Fanalca.BL.Interfaces.Fanalca;

namespace CSharp.DanielArana.Fanalca.API
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

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CSharp.DanielArana.Fanalca.API", Version = "v1" });
            });

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IManagementTokenBL, ManagementToken>();

            services.AddTransient<IAPIClaimBL, APIClaimBL>();

            services.AddTransient<IAuthBL, AuthBL>();


            ///////////////////////
            ///
            services.AddTransient<IAreasBL, AreasBL>();
            services.AddTransient<IEmployeesBL, EmployeesBL>();
            services.AddTransient<ISubAreasBL, SubAreasBL>();
            services.AddTransient<IDocumentTypeBL, DocumentTypeBL>();


            services.AddDbContext<FanalcaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DB"))
             );

            var appSettingsSection = Configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {

                  options.SaveToken = true;
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = appSettings.IssuerLogin,
                      ValidAudience = appSettings.Audience,
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.SecretLogin)),//llave secreta
                      ClockSkew = TimeSpan.Zero
                  };
              });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors("MyPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CSharp.DanielArana.Fanalca.API v1"));
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
