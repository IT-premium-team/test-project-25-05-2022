using AspNetCoreRateLimit;
using AutoMapper;

using Api;
using Data;
using Data.Mappers;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//configure services for DI
builder.Services.AddTransient<IDbService, DataService>();
builder.Services.AddTransient<IApiService, ApiService>();

//configure mapper
var mapperConfiguration = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<UserDtoMappingProfile>();
    cfg.AddProfile<PostDtoMappingProfile>();
    cfg.AddProfile<CommentDtoMappingProfile>();
});
builder.Services.AddSingleton(mapperConfiguration.CreateMapper());

ContainerConfiguration.Configure(builder.Services, builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// needed to store rate limit counters and ip rules
builder.Services.AddMemoryCache();

//load general configuration from appsettings.json
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));

// inject counter and rules stores
builder.Services.AddInMemoryRateLimiting();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

var app = builder.Build();

app.UseIpRateLimiting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
