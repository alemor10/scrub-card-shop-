using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using scrubcardshopAPI.Services;
using scrubcardshopAPI.DataAccess.UserData;
using scrubcardshopAPI.Services.UserServices;
using scrubcardshopAPI.Services.UserRepository;


namespace scrubcardshopAPI
{
    public class Startup
    {
        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration {get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserMapping());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserContext, UserContext>();
            services.AddTransient<IUserRepository, UserRepository>();

            //services.AddScoped<CardService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseEndpoints(endpoints => {
                endpoints.MapDefaultControllerRoute();
            });

            
        }
    }
}
