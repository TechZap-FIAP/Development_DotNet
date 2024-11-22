using APITechZap.Data;
using APITechZap.Repository;
using APITechZap.Repository.Interface;
using APITechZap.Services.ArtificialIntelligence;
using APITechZap.Services.Authentication;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Net.Http.Headers;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection"))
        .LogTo(Console.WriteLine, LogLevel.Information)
);

FirebaseApp.Create(new AppOptions
{
    Credential = GoogleCredential.FromFile("techzap-firebase.json")
});

builder.Services.AddHttpClient<IAuthService, AuthService>((sp, httpClient) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    httpClient.BaseAddress = new Uri(configuration["Authentication:TokenUri"]!);
});

// Add Transient - AI Service
builder.Services.AddTransient<IAiService, AiService>();

// Add Scoped Tables
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserAdditionalDataRepository, UserAdditionalDataRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IContractedPlanRepository, ContractedPlanRepository>();
builder.Services.AddScoped<ISolarPanelRepository, SolarPanelRepository>();
builder.Services.AddScoped<IWindTurbineRepository, WindTurbineRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api da Plataforma TechZap de Energia Economica e Sustentável",
        Version = "v1.0.0",
        Description = "Esta api tem como funcionalidade ser um BackEnd para que seja utilizado por outras aplicações web e etc.",
        Contact = new OpenApiContact
        {
            Name = "TechZap",
            Email = "technosfiap@gmail.com"
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
