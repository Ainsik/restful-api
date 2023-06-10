using api.DbContext;
using api.DTOs.Validators;
using api.DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;
using Polly;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<RestDbContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("BackendConnectionString")));

builder.Services.AddScoped<IValidator<BaseDoctorDto>, BaseDoctorDtoValidator>();
builder.Services.AddScoped<IValidator<CreateDoctorDto>, CreateDoctorDtoValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<RestDbContext>();
var pendingMigrations = dbContext.Database.GetPendingMigrations();

var policy = Policy
    .Handle<Exception>()
    .WaitAndRetry(3, attempt => TimeSpan.FromSeconds(attempt * 3));

policy.Execute(() =>
{
    if (pendingMigrations.Any()) dbContext.Database.Migrate();
});

app.Run();
