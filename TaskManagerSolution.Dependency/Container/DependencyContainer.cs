using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TaskManagerSolution.Application.Interfaces.IContexts;
using TaskManagerSolution.Application.Interfaces.IFasde;
using TaskManagerSolution.Application.Services.Fasade;
using TaskManagerSolution.Persistence.Contexts;
using Microsoft.AspNetCore.Builder;

namespace TaskManagerSolution.Dependency.Container;

public class DependencyContainer {
    public static void RegisterServices(IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<IDataBaseContext, DataBaseContext>(option => {
            option.UseSqlServer(configuration.GetConnectionString("Default"));
        });
        services.AddScoped<IUserFasade, UserFasade>();
    }
}