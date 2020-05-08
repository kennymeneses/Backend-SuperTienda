using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SuperTienda.BusinessLayer.Core;
using SuperTienda.BusinessLayer.Manager.UsuarioManagement;
using SuperTienda.BusinessLayer.Manager.CategoriaManagement;
using SuperTienda.BusinessLayer.Manager.SubCategoriaManagement;
using SuperTienda.BusinessLayer.Manager.SubSubCategoriaManagement;
using SuperTienda.BusinessLayer.Manager.ProductoManagement;
using SuperTienda.DataAccess.Core;


namespace SuperTienda.ServiceApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbFactory, DbFactory>();
            services.AddScoped<DataContext>();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IUsuarioManager, UsuarioManager>();
            services.AddScoped<ICategoriaManager, CategoriaManager>();
            services.AddScoped<ISubCategoriaManager, SubCategoriaManager>();
            services.AddScoped<ISubSubCategoriaManager, SubSubCategoriaManager>();
            services.AddScoped<IProductoManager, ProductoManager>();
            services.AddScoped<BusinessManagerFactory>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "yourdomain.com",
                ValidAudience = "yourdomain.com",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Llave_secreta"])),ClockSkew = TimeSpan.Zero
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(x =>
            {
                x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            });
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
         
        }
    }
}
