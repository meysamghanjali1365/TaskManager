using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TaskManagerSolution.Application.Interfaces.IContexts;
using TaskManagerSolution.Application.Interfaces.IFasde;
using TaskManagerSolution.Application.Services.Fasade;
using TaskManagerSolution.Persistence.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace TaskManagerSolution.Dependency.Container;

public class DependencyContainer {
    public static void RegisterServices(IServiceCollection services, IConfiguration configuration) {
        services.AddAuthentication(options => {
            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        }).AddCookie(options => {
            options.LoginPath = new PathString("/Authentication/Signin");
            options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
        });
        services.AddDbContext<IDataBaseContext, DataBaseContext>(option => {
            option.UseSqlServer(configuration.GetConnectionString("Default"));
        });
        services.AddScoped<IUserFasade, UserFasade>();
        services.AddScoped<IRoleFasade, RoleFasade>();
        services.AddScoped<ICategoryFasade, CategoryFasade>();
    }
}