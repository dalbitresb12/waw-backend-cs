using WAW.API.Auth.Authorization.Handlers.Implementations;
using WAW.API.Auth.Authorization.Handlers.Interfaces;
using WAW.API.Auth.Domain.Repositories;
using WAW.API.Auth.Domain.Services;
using WAW.API.Auth.Persistence.Repositories;
using WAW.API.Auth.Services;

namespace WAW.API.Auth.Injection;

public static class AuthInjections {
  public static void Register(IServiceCollection services) {
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IUserService, UserService>();

    services.AddScoped<IUserEducationRepository, UserEducationRepository>();
    services.AddScoped<IUserEducationService, UserEducationService>();

    services.AddScoped<IJwtHandler, JwtHandler>();
  }
}
