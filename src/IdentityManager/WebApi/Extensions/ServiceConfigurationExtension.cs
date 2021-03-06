using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Travely.IdentityManager.Repository.Abstractions.Entities;
using Travely.IdentityManager.Service.Abstractions;
using Travely.IdentityManager.Service.Abstractions.Models;
using Travely.IdentityManager.Service.Identity;
using Travely.IdentityManager.WebApi.Filters;

namespace Travely.IdentityManager.WebApi.Extensions
{
    public static class ServiceConfigurationExtension
    {
        public static void ConfigureFilterServices(this IServiceCollection services)
        {
            services.AddControllers(config =>
            {
                config.Filters.Add(new ValidateModelStateActionFilter());
            });

            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }

        public static UserContextModel GetUserContext(this HttpContext context)
        {
            var claims = context?.User?.Claims;
            UserContextModel userContext = new UserContextModel();
            userContext.Role = claims.First(p => p.Type.Contains("role")).Value.ToEnum<Role>();
            userContext.UserId = int.Parse(claims.First(p => p.Type == "sub").Value);
            userContext.AgencyId = int.Parse(claims.First(p => p.Type == "AgencyId").Value);

            return userContext;
        }

        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }

}
