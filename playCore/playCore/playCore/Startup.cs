using playCore.Options;
using playCore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace playCore
{
    public class Startup
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public Startup(IHostingEnvironment env)
        {
            hostingEnvironment = env;
        }

        private void ConfigureSettings(IServiceCollection services)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("alertThresholds.json")
                .AddJsonFile($"alertThresholds{hostingEnvironment.EnvironmentName}.json", optional: true);
            var config = configBuilder.Build();

            services.Configure<ThresholdOptions>(config);
            services.AddOptions();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureSettings(services);
            services.AddMvc();

            services.AddSingleton<ISensorDataService, SensorDataService>();
            services.AddScoped<IViewModelService, ViewModelService>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {

            app.UseStaticFiles();

            if (hostingEnvironment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.Use(next => context =>
            {
                context.Response.Headers["IGNITE-HEADER"] = "WOOT!";
                return next(context);
            });

            app.UseMiddleware<XHttpHeaderOverrideMiddleware>();
            app.UseMiddleware(typeof(MyMiddleware), "yo");

            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();


        }
    }
}
