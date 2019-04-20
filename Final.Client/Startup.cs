using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Blazored.LocalStorage;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using Final.Client.AppState;
using Final.Shared;
using Final.Client.Interface;
using Final.Client.Service;
using Final.Client.Interface.AppState;

namespace Final.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<UserState>();
            services.AddSingleton<LearningState>();

            services.AddTransient<IAuthServices, AuthServices>();
            services.AddTransient<IRestServices, RestServices>();


            services.AddBlazoredLocalStorage();
            services.AddLoadingBar();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
            app.UseLoadingBar();
        }
    }
}
