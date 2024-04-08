using Bll;
using Bll.Interfaces;
using Bll.Services;
using Dal.Interfaces;
using Dal.Models;
using Dal.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CommunalWazeContext>(options => options.UseSqlServer("Server= DESKTOP-S16FV2M\\SQLEXPRESS; Database= CommunalWaze;TrustServerCertificate=True;Trusted_Connection=True;"));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddScoped(typeof(IUserService), typeof(UserService));

builder.Services.AddScoped(typeof(IReportRepository), typeof(ReportRepository));
builder.Services.AddScoped(typeof(IReportService), typeof(ReportService));

builder.Services.AddScoped(typeof(ISaveSearchRepository), typeof(SaveSearchRepository));
builder.Services.AddScoped(typeof(ISaveSearchService), typeof(SaveSearchService));

builder.Services.AddScoped(typeof(IReportsCategoryRepository), typeof(ReportsCategoryRepository));
builder.Services.AddScoped(typeof(IReportsCategoryService), typeof(ReportCategoryService));

builder.Services.AddHostedService<WorkerService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("https://localhost:7071", "http://localhost:3000")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
