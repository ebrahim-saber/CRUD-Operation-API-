using Frist_API_Project;
using Frist_API_Project.Data;
using Frist_API_Project.Repository;
using Frist_API_Project.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>
    (option => option.UseSqlServer(builder.Configuration.GetConnectionString("DataBaseConnection")));
builder.Services.AddAutoMapper(typeof(MappingConfig));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ILogging, Logging>();
builder.Services.AddScoped<ILogging,Logging>();
builder.Services.AddSingleton<ILogging, Logging>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

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
