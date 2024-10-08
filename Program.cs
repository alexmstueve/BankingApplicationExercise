using BankingApplicationExercise.Dtos;
using BankingApplicationExercise.Interfaces;
using BankingApplicationExercise.Repositories;
using BankingApplicationExercise.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IBankAccountService, BankAccountService>();

// Add repositories
builder.Services.AddSingleton<IBankAccountRepository, BankAccountRepository>();

// Add configuration
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
builder.Services.Configure<AppConfigurationDto>(
    builder.Configuration.GetSection("AppConfiguration")
);


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

app.Run();
