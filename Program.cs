using System.Text;
using Api.Data;
using Api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CaityContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<MemberAuthentication>();
builder.Services.AddScoped<MemberAuthorization>();
builder.Services.AddScoped<MemberRegistration>();
builder.Services.AddAuthentication().AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
{
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    ValidAudience = builder.Configuration["Jwt:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
});

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
