
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using DD.Shared.Attributes;
using DD.Shared;
using DD.Shared.DataAccess;
using DD.Shared.Enums;
using DD.Shared.Services;
using DiagnPortal.API.Data;
using Microsoft.EntityFrameworkCore;

namespace DiagnPortal.Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
        });
builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                b => b
                    .WithOrigins("http://localhost:4200","https://localhost:4200","http://127.0.0.1:4200",builder.Configuration["FrontEndUrl"])
                    //.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
        });

        builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            })
            .AddBearerToken(IdentityConstants.BearerScheme);

        builder.Services.AddAuthorizationBuilder()
            .AddPolicy("CanViewName", policy => policy.RequireClaim(Policy.CanViewName, "true"))
            .AddPolicy("CanViewContact", policy => policy.RequireClaim(Policy.CanViewContact, "true"))
            .AddPolicy("CanViewAddress", policy => policy.RequireClaim(Policy.CanViewAddress, "true"))
            .AddPolicy("CanViewCharacteristics", policy => policy.RequireClaim(Policy.CanViewCharacteristics, "true"))
            .AddPolicy("AdminPolicy", policy => policy.RequireRole(Role.Administrator))
            .AddPolicy("OperatorPolicy", policy => policy.RequireRole(Role.Operator))
            .AddPolicy("AffiliatePolicy", policy => policy.RequireRole(Role.Affiliate))
            .AddPolicy("GuestPolicy", policy => policy.RequireRole(Role.Guest));
        builder.Services.AddSharedCensorService();
        builder.Services.AddDbContext<DbContextBase>();
        builder.Services.AddDbContext<ReadDbContext>();

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("oauth2",
                new OpenApiSecurityScheme
                {
                    Description = "The API Key to access the API",
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = ParameterLocation.Header
                });
            c.OperationFilter<SecurityRequirementsOperationFilter>();
        });


        var app = builder.Build();

        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();
        app.UseForwardedHeaders();

        app.UseCors("CorsPolicy");

        app.UseAuthorization();

        app.MapGet("/claims", (ClaimsPrincipal user) =>
        {
            var claims = user.Claims.Select(c => new { c.Type, c.Value });
            return Results.Ok(claims);
        }).RequireAuthorization();
        app.MapGet("/secure-endpoint", (ClaimsPrincipal user) => $"Hello {user.Identity!.Name}")
            .RequireAuthorization();
        app.MapGet("/admin-endpoint", (ClaimsPrincipal user) => $"Hello {user.Identity!.Name}")
            .RequireAuthorization("AdminPolicy");
        app.MapGet("/test-data", (ClaimsPrincipal user) =>
        {
            var data = GetData();
            var cen = new CensorService();
            return Results.Ok(cen.Censor(data,user));
        }).RequireAuthorization();

        app.MapControllers();

        app.MapFallbackToFile("/index.html");

        app.Run();
    }

    public static TestModel GetData()
    {
        return new TestModel
        {
            Id = default,
            FirstName = "Alex",
            LastName = "Patsouros",
            Email = "who@this.gr"
        };
    }
    public class TestModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Censor("CanViewName")]
        public string FirstName { get; set; }
        [Censor("CanViewName")]
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}