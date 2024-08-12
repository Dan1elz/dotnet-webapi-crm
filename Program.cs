using dotnet_webapi_erp;
using dotnet_webapi_erp.App.Controllers;
using dotnet_webapi_erp.App.Models.Concrete.Company;
using dotnet_webapi_erp.App.Models.Concrete.Token;
using dotnet_webapi_erp.App.Models.Concrete.User;
using dotnet_webapi_erp.App.Services;
using dotnet_webapi_erp.Data;
using dotnet_webapi_erp.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
{
    policy.WithOrigins("http://localhost:4200");
    policy.AllowCredentials();
    policy.AllowAnyMethod();
    policy.AllowAnyHeader();
    policy.SetIsOriginAllowed(_ => true);
}));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

builder.Services.AddScoped<AppDbContext>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ITokenRepository, TokenRepository>();
builder.Services.AddTransient<IUtilsService, UtilsService>();
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();

var key = Encoding.ASCII.GetBytes(Key.secret);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services.AddAuthorization();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

// **Ordem correta dos middlewares**
app.UseRouting();  // Certifique-se de que está antes de app.UseAuthentication()

app.UseAuthentication();  // Certifique-se de que está antes de app.UseAuthorization()
app.UseAuthorization();

app.MapControllers();

app.Run();
