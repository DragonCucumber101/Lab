using Lab.Data;
using Microsoft.EntityFrameworkCore;
using SignalRApp;
using System.ComponentModel;
// Является стартовой точкой для программы. Здесь происходит стартовая настройка и app.Run() запускает проект
var a = 0;
var builder = WebApplication.CreateBuilder(args); //
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")).UseSnakeCaseNamingConvention());

builder.Services.AddControllers();
builder.Services.AddSignalR(); // Добавлено

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles(); // Добавлено
app.UseStaticFiles();  // Добавлено

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<ChatHub>("/chat"); 

app.Run();

