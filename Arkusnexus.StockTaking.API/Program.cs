using Arkusnexus.StockTaking.API;
using Arkusnexus.StockTaking.ApplicationCore.Application.Interfaces;
using Arkusnexus.StockTaking.ApplicationCore.Application.Services;
using Arkusnexus.StockTaking.ApplicationCore.Core.Entities;
using Arkusnexus.StockTaking.ApplicationCore.Core.Interfaces;
using Arkusnexus.StockTaking.Infrastructure.Commun;
using Arkusnexus.StockTaking.Infrastructure.Data;
using Arkusnexus.StockTaking.Infrastructure.Repositories;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(options => {
    options.ImplicitlyValidateChildProperties = true;
    options.ImplicitlyValidateRootCollectionElements = true;

    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()); 
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<StockTakingDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnStr")));

// For Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<StockTakingDbContext>()
    .AddDefaultTokenProviders();

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});

builder.Services.AddScoped<IMailService,MailService>();

builder.Services.AddScoped<IGenericRepository<Device>, GenericRepository<Device>>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IDeviceService, DeviceService>();


builder.Services.AddScoped<IGenericRepository<DeviceItem>, GenericRepository<DeviceItem>>();
builder.Services.AddScoped<IDeviceItemRepository, DeviceItemRepository>();
builder.Services.AddScoped<IDeviceItemService, DeviceItemService>();

builder.Services.AddSwaggerGen();


var mapperConfig = new MapperConfiguration(x =>
{
    x.AddProfile(new MappingProfile());
});

IMapper mappper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mappper);

builder.Services.AddMvc();

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
