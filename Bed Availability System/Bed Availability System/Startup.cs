using Bed_Availability_System.Extentions;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bed_Availability_System
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
          LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),"/nlog.config"));

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Env { get; set; } //add

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<Account, AppRole>(options => {
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedAccount = true;
            }).AddEntityFrameworkStores<RepositoryContext>();
            services.AddAutoMapper(typeof(Startup));

            services.AddAuthentication();
           // services.ConfigureIdentity();
            services.ConfigureLoggerService();
          //  services.ConfigureJWT(Configuration);

            services.ConfigureCors();
            services.ConfigureIISIntegration();
            services.ConfigureSqlContext(Configuration);
            services.ConfigureRepositoryManager();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bed_Availability_System", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bed_Availability_System v1"));
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
           app.UseCors("CorsPolicy");
            app.UseForwardedHeaders(new ForwardedHeadersOptions
           {
                ForwardedHeaders = ForwardedHeaders.All
            });


            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<Account>>();

            IdentityResult roleResult;
            //here in this line we are adding Admin Role 
            string[] roleNames = { "Admin", "Staff", "Customer" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    var role = new AppRole();
                    role.Name = roleName;
                    roleResult = await RoleManager.CreateAsync(role);
                }
            }

            //be assigned to that user.
            var userCheck = await UserManager.FindByEmailAsync("yashrajtiwari32@gmail.com");
            if (userCheck == null)
            {
                Account userAdmin = new Account();
                userAdmin.UserName = "yash";
                userAdmin.Email = "yashrajtiwari32@@gmail.com";
                userAdmin.Password = "yash";
                userAdmin.ConfirmPassword = "yash";
                userAdmin.City = "pune";
                userAdmin.PhoneNumber = "7840992748";
                userAdmin.SecurityStamp = Guid.NewGuid().ToString();
                var _user = await UserManager.FindByEmailAsync(userAdmin.Email);

                if (_user == null)
                {
                    var createuserAdmin = await UserManager.CreateAsync(userAdmin);
                    if (createuserAdmin.Succeeded)
                    {
                        //here we tie the new user to the role
                        await UserManager.AddToRoleAsync(userAdmin, "Admin");

                    }
                }
            }
        }
    }
}
