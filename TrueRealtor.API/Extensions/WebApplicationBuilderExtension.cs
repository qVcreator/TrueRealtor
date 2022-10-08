using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TrueRealtor.API.Infrastructure;
using TrueRealtor.Business.Interfaces;
using TrueRealtor.Business.Services;
using TrueRealtor.Data;
using TrueRealtor.Data.Interfaces;
using TrueRealtor.Data.Repositories;

namespace TrueRealtor.API.Extensions;

public static class WebApplicationBuilderExtension
{
    public static void SetupServices(this IServiceCollection services)
    {
        services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var result = new BadRequestObjectResult(context.ModelState);
                    result.StatusCode = StatusCodes.Status422UnprocessableEntity;
                    return result;
                };
            });

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "True Realtor", Version = "v1" });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Authorization: Bearer JWT",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                Scheme = "Bearer",
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer",
                        },
                    },
                    Array.Empty<string>()
                },
            });
        });

        services.AddAuthorization();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = AuthOptions.Issuer,
                    ValidateAudience = true,
                    ValidAudience = AuthOptions.Audience,
                    ValidateLifetime = true,
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true,
                };
            });

        services.AddDbContext<TrueRealtorContext>(b=>
        {
            b.UseSqlServer(System.Environment.GetEnvironmentVariable("TRUEREALTORE_CONNECTION_STRING", EnvironmentVariableTarget.Machine)!);
        });

        services.AddScoped<IApartmentsService, ApartmentsService>();
        services.AddScoped<IApartmentsRepository, ApartmentsRepository>();
        services.AddScoped<IAuthService, AuthService>();

        services.AddAutoMapper(typeof(MapperConfig));
    }
}
